using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using MedicineAdministration.Dal.Dbcontext;

namespace MedicineAdministration.Resposity.DbContext
{
    public partial class EduBase:DbContext
    {
        public EduBase()
            : base("EduBase")
        {
        }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<tb_Department> Departments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public override int SaveChanges(string message)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.HasDefaultSchema("dbo");
            dbModelBuilder.Entity<tb_Department>().ToTable("tb_Department");
            dbModelBuilder.Entity<User>().ToTable("tb_User");
            dbModelBuilder.Entity<Post>().ToTable("tb_Post");
            dbModelBuilder.Entity<tb_Department>()
                .Property(e => e.Department1)
                .IsUnicode(false);
            dbModelBuilder .Entity <Post  >()
                .Property (e=>e.Post1 )
                .IsUnicode (false);
            dbModelBuilder.Entity<User>()
                .Property(e => e.NO)
                .IsFixedLength()
                .IsUnicode(false);
            dbModelBuilder.Entity<User>()
                .Property(e => e.Gender);
            dbModelBuilder .Entity <User >()
                .Property (e => e.Name)
                .IsUnicode (false);
            dbModelBuilder .Entity <User >()
                .Property (e=>e.Salary )
                .IsUnicode (false);
            dbModelBuilder.Entity <User>()
                .Property (e=>e.Number )
                .IsUnicode (false);
            dbModelBuilder.Entity<User>()
                .Property(e => e.WorkTime)
                .GetType();
            dbModelBuilder .Entity<User>()
                .Property (e=>e.Birthday )
               .GetType ();
        }
    }
}
