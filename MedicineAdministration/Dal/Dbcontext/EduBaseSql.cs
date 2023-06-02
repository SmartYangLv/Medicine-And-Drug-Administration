using MedicineAdministration.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAdministration.Dal.Dbcontext
{
    public partial  class EduBaseSql:MyDbContext 
    {
        public EduBaseSql ():base("name=EduBasepgsql")
        {

        }
        public virtual DbSet<User  >User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Department >()
            //    .Property(e => e.Department1)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Post>()
            //    .Property(e => e.Post1)
            //    .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.NO)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Salary)
                .IsUnicode(false);

        }
        public override int SaveChanges(string notUniqueErrorMessage)
        {
            int rowAffected = 0;
            try
            {
                rowAffected = this.SaveChanges();
            }
            catch (Exception ex)
            {
                NpgsqlException pgsqlEx = ex.InnerException.InnerException as NpgsqlException;
                if(pgsqlEx .Message .Substring(0, 5) == "23505")
                {
                    throw new ApplicationException(notUniqueErrorMessage);
                }
                throw;
            }
            return rowAffected;
        }
    }
}
