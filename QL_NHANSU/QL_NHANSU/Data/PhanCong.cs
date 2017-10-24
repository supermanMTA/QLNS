namespace QL_NHANSU.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanCong")]
    public partial class PhanCong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaNV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaDA { get; set; }

        [StringLength(10)]
        public string SoGio { get; set; }
    }
}
