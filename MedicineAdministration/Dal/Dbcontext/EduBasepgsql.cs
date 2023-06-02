using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Npgsql;
using MedicineAdministration.Model;

namespace MedicineAdministration.Dal.Dbcontext
{
    public partial class EduBasepgsql : MyDbContext
    {
        public EduBasepgsql()
            : base("name=EduBasepgsql")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<User >().ToTable("tb_User");
            modelBuilder.Entity<User>()
                .Property(e => e.NO)
                .IsFixedLength()
                .IsUnicode(false)
                .HasColumnName("No");
            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .HasColumnName("Password");
            modelBuilder.Entity<User>()
                .Property(e => e.IsActivated)
                .HasColumnName("is_activated");
            modelBuilder.Entity<User>()
                .Property(e => e.LoginFailCount)
                .HasColumnName("logon_fail_count");
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
                if (pgsqlEx.Message.Substring(0, 5) == "23505")
                {
                    throw new ApplicationException(notUniqueErrorMessage);
                }
                throw;
            }
            return rowAffected;
        }
    }
}

