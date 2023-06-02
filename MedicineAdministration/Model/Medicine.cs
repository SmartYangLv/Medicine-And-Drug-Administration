namespace MedicineAdministration.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medicine
    {
        [Key]
        [StringLength(20)]
        public string NO { get; set; }

        [Required]
        [StringLength(50)]
        public string MedicineName { get; set; }

        [StringLength(40)]
        public string PINYIN { get; set; }

        public int? MedicineClassify { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        public int? AreaNo { get; set; }

        [StringLength(100)]
        public string Specification { get; set; }

        public int? InventoryQuantity { get; set; }

        public int? UnitNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationTime { get; set; }

        public double? Price { get; set; }

        [StringLength(100)]
        public string Action { get; set; }

        public int? IsActioned { get; set; }
    }
}
