namespace QL_NHANSU.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBan")]
    public partial class PhongBan
    {
        [Key]
        [StringLength(10)]
        public string MaPB { get; set; }

        [StringLength(50)]
        public string TenPB { get; set; }

        [StringLength(10)]
        public string MaTP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ng_NC { get; set; }

        [StringLength(3)]
        public string SoNV { get; set; }
    }
}
