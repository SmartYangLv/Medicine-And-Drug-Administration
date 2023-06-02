namespace MedicineAdministration.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [StringLength(20)]
        public string NO { get; set; }

        [Required]
        [MaxLength(128)]
        public byte[] Password { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public bool? Gender { get; set; }

        [StringLength(20)]
        public string Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime? WorkTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public int? Post { get; set; }

        public int? Department { get; set; }

        [StringLength(20)]
        public string Salary { get; set; }

        public byte[] Photo { get; set; }

        public bool? IsActivated { get; set; }

        public int LoginFailCount { get; set; }
    }
}
