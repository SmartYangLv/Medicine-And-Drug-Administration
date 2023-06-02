using MedicineAdministration.Dal.Dbcontext;
using MedicineAdministration.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MedicineAdministration.Dal
{
    /// <summary>
    /// 数据访问层
    /// </summary>
    public class UserDal : IUserDal
    {

        public int insert(User user)
            => EfHelper.Save(user, EntityState.Added, "您提交的用户已存在");

        public UserDal()
            => EfHelper.WarmUp();
        public int SelectCount(string UserNo)
            => EfHelper.SelectCount<User>(u => u.NO == UserNo);

        public User Selet(string UserNo)
            => EfHelper.SelectOne<User>(u => u.NO == UserNo);


        public int Update(User user)
            => EfHelper.Save(user, EntityState.Modified);


        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public int insert(Model.User user)
        //{
        //    //int rowAffected = 0;
        //    //try
        //    //{
        //    //    rowAffected =
        //    //        this.sqlHelper
        //    //        .NewCommand("INSERT tb_User (NO,Password ,IsActivated )VALUES(@No,@Password,@IsActivated)")
        //    //        .IsStoreProcedure()
        //    //        .NewParameter("@No", user.No)
        //    //        .NewParameter("@Password", user.Password)
        //    //        .NewParameter("@IsActivated", user.IsActivated)
        //    //        .NonQuery();
        //    //}
        //    //catch (NotUniqueException)
        //    //{
        //    //    throw new ApplicationException("您提交的用户名已存在！");
        //    //}
        //    //catch (Exception )
        //    //{
        //    //    throw;
        //    //}
        //    //return rowAffected;



        //    SqlConnection sqlConnection = new SqlConnection();
        //    sqlConnection.ConnectionString =
        //        ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        //    SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //    sqlCommand.CommandText = $@"INSERT tb_User (NO,Password ,IsActivated )
        //            VALUES(@No,@Password,@IsActivated)";
        //    sqlCommand.Parameters.AddWithValue("@No", user.No);
        //    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
        //    sqlCommand.Parameters.AddWithValue("@IsActivated", user.IsActivated);
        //    int rowAffected = 0;
        //    try
        //    {
        //        sqlConnection.Open();
        //        rowAffected = sqlCommand.ExecuteNonQuery();
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        if (sqlex.Number == 2627)
        //        {
        //            throw new ApplicationException("您提交的用户已存在");
        //        }
        //        throw sqlex;
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //    return rowAffected;
        //}
        ///// <summary>
        ///// 查询用户计数
        ///// </summary>
        ///// <param name="UserNo"></param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public int SelectCount(string UserNo)
        ////=> this.sqlHelper
        ////.NewCommand("SELECT COUNT(1) FROM tb_User WHERE No=@No")
        ////.IsStoreProcedure()
        ////.NewParameter("@No", UserNo)
        ////.GetScalar<int>();



        //{
        //    SqlConnection sqlConnection = new SqlConnection();
        //    sqlConnection.ConnectionString =
        //            ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        //    SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //    sqlCommand.CommandText = $@"SELECT COUNT(1) FROM tb_User WHERE No=@No";
        //    sqlCommand.Parameters.AddWithValue("@No", UserNo);
        //    sqlConnection.Open();
        //    int count = (int)sqlCommand.ExecuteScalar();
        //    sqlConnection.Close();
        //    return count;
        //}
        ///// <summary>
        ///// 查询用户
        ///// </summary>
        ///// <param name = "UserNo" ></ param >
        ///// < returns ></ returns >
        ///// < exception cref="NotImplementedException"></exception>
        //public Model.User Selet(string UserNo)
        //{
        //    //IDataReader dataReader =
        //    //    this.sqlHelper
        //    //    .NewCommand("SELECT Password ,IsActivated ,LoginFailCount,Name FROM tb_User WHERE No =@No")
        //    //    .IsStoreProcedure()
        //    //    .NewParameter("@No", UserNo)
        //    //    .GetReader();
        //    //User user = null;
        //    //if(dataReader .Read())
        //    //{
        //    //    user =new User()
        //    //    {
        //    //        No= UserNo,
        //    //        Password = (byte[])dataReader ["Password"],
        //    //        IsActivated = (bool)dataReader["IsActivated"],
        //    //        LoginFailCount = (int)dataReader["LoginFailCount"],
        //    //        UserName = (string)dataReader["Name"],
        //    //    };
        //    //}
        //    //return user;



        //    SqlConnection sqlConnection = new SqlConnection();
        //    sqlConnection.ConnectionString =
        //        ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        //    SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //    sqlCommand.CommandText = $@"SELECT Password ,IsActivated ,LoginFailCount,Name
        //       FROM tb_User WHERE NO =@No";
        //    sqlCommand.Parameters.AddWithValue("@No", UserNo);
        //    sqlConnection.Open();
        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        //    Model.User user = null;
        //    if (sqlDataReader.Read())
        //    {
        //        user = new Model.User()
        //        {
        //            No = UserNo,
        //            Password = (byte[])sqlDataReader["Password"],
        //            IsActivated = (bool)sqlDataReader["IsActivated"],
        //            LoginFailCount = (int)sqlDataReader["LoginFailCount"],
        //            UserName = (string)sqlDataReader["Name"],
        //        };
        //    }
        //    sqlDataReader.Close();
        //    return user;
        //}
        ///// <summary>
        ///// 更新用户
        ///// </summary>
        ///// <param name="user"></param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public int Update(Model.User user)
        //{
        //    //=> this.sqlHelper
        //    //    .NewCommand("UPDATE tb_User  SET  Password =@Password,IsActivated =@IsActivated, LoginFailCount =@LoginFailCount WHERE NO =@No")
        //    //    .IsStoreProcedure()
        //    //    .NewParameter("@No", user.No)
        //    //    .NewParameter("@Password", user.Password)
        //    //    .NewParameter("@IsActivated", user.IsActivated)
        //    //.NewParameter("@LoginFailCount", user.LoginFailCount)
        //    //.NonQuery();



        //    SqlConnection sqlConnection = new SqlConnection();
        //    sqlConnection.ConnectionString =
        //            ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        //    SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //    sqlCommand.CommandText = $@"UPDATE tb_User 
        //                          SET 
        //                    Password =@Password,
        //                IsActivated =@IsActivated,
        //                LoginFailCount =@LoginFailCount
        //                WHERE NO =@No";
        //    sqlCommand.Parameters.AddWithValue("@No", user.No);
        //    sqlCommand.Parameters.AddWithValue("@IsActivated", user.IsActivated);
        //    sqlCommand.Parameters.AddWithValue("@LoginFailCount", user.LoginFailCount);
        //    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
        //    sqlConnection.Open();
        //    int rowAffected = sqlCommand.ExecuteNonQuery();
        //    sqlConnection.Close();
        //    return rowAffected;
        //}
    }
}
