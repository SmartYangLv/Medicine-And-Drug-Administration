using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MedicineAdministration.Dal.Dbcontext
{
    public  class EfHelper
    {
        private static bool HasWarmedUp { get; set; }

        public static MyDbContext GetDbContext()
            => new EduBasepgsql ();
       /// <summary>
       /// 预热
       /// </summary>
        public static async void WarmUp()
        {
            if(HasWarmedUp)
            {
                return;
            }
            using (MyDbContext eduBase=GetDbContext())
            {
                await Task.Run(() => eduBase.Database.ExecuteSqlCommand("SELECT 1"));
            }
        }
        /// <summary>
        /// 查询计数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="match"></param>
        /// <returns></returns>
        public static int SelectCount<T>(Expression <Func<T,bool >>match)where T : class
        {
            using (MyDbContext eduBase=GetDbContext())
            {
                return eduBase .Set <T >().Where (match).Count ();
            }
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="match"></param>
        /// <returns></returns>
        public static T SelectOne<T>(Expression<Func<T,bool>> match) where T : class
        {
            using (MyDbContext eduBase = GetDbContext())
            {
                return eduBase .Set <T > ().Where (match).FirstOrDefault();
            }
        }
       /// <summary>
       /// 查询实体
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="match"></param>
       /// <returns></returns>
        public static IQueryable<T> Select<T>(Expression<Func<T, bool>> match) where T : class 
        {
            using (MyDbContext eduBase=GetDbContext())
            {
                return eduBase.Set<T>().Where(match);
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="entityState"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int Save<T>(T entity,EntityState entityState ,string message="")where T : class
        {
            using (MyDbContext eduBase = GetDbContext())
            {
                eduBase .Entry (entity ).State = entityState;
                return eduBase .SaveChanges (message );
            }
        }
        static EfHelper()
        {
            HasWarmedUp = false;
        }
    }
}
