namespace QL_NHANSU.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QL_NS : DbContext
    {
        public QL_NS()
            : base("name=QL_NS")
        {
        }

        public virtual DbSet<DuAn> DuAns { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanCong> PhanCongs { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<ThanNhan> ThanNhans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DuAn>()
                .Property(e => e.MaDA)
                .IsFixedLength();

            modelBuilder.Entity<DuAn>()
                .Property(e => e.MaPB)
                .IsFixedLength();

            modelBuilder.Entity<DuAn>()
                .Property(e => e.tongsogio)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.GTinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Luong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaPB)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.NgGS)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoNVDuoiQuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Chucvu)
                .IsFixedLength();

            modelBuilder.Entity<PhanCong>()
                .Property(e => e.MaNV)
                .IsFixedLength();

            modelBuilder.Entity<PhanCong>()
                .Property(e => e.MaDA)
                .IsFixedLength();

            modelBuilder.Entity<PhanCong>()
                .Property(e => e.SoGio)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.MaPB)
                .IsFixedLength();

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.MaTP)
                .IsFixedLength();

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.SoNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThanNhan>()
                .Property(e => e.MaNV)
                .IsFixedLength();

            modelBuilder.Entity<ThanNhan>()
                .Property(e => e.GioiTinh)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
