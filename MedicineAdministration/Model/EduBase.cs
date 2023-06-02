using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MedicineAdministration.Model
{
    public partial class EduBase : DbContext
    {
        public EduBase()
            : base("name=EduBase")
        {
        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tb_User");
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
    }
}
