namespace QL_NHANSU.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string DChi { get; set; }

        [StringLength(3)]
        public string GTinh { get; set; }

        [StringLength(10)]
        public string Luong { get; set; }

        [StringLength(10)]
        public string MaPB { get; set; }

        [StringLength(10)]
        public string NgGS { get; set; }

        [StringLength(3)]
        public string SoNVDuoiQuyen { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(10)]
        public string Chucvu { get; set; }
    }
}
