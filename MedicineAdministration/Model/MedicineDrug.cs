using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MedicineAdministration.Model
{
    public partial class MedicineDrug : DbContext
    {
        public MedicineDrug()
            : base("name=MedicineDrug3")
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().ToTable("tb_Area");
            modelBuilder.Entity<Country>().ToTable("tb_Country");
            modelBuilder.Entity<Medicine>().ToTable("tb_Medicine");
            modelBuilder.Entity<Area>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.NO)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.MedicineName)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.PINYIN)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Manufacturer)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Specification)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Action)
                .IsUnicode(false);
        }
    }
}
