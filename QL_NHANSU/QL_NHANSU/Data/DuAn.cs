namespace QL_NHANSU.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuAn")]
    public partial class DuAn
    {
        [Key]
        [StringLength(10)]
        public string MaDA { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDA { get; set; }

        [StringLength(10)]
        public string MaPB { get; set; }

        [StringLength(50)]
        public string DiaDiem { get; set; }

        [StringLength(10)]
        public string tongsogio { get; set; }
    }
}
