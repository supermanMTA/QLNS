USE [master]
GO
/****** Object:  Database [QL_NHANSU]    Script Date: 10/23/2017 11:44:16 AM ******/
CREATE DATABASE [QL_NHANSU]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_NHANSU', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_NHANSU.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_NHANSU_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_NHANSU_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_NHANSU] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_NHANSU].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_NHANSU] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_NHANSU] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_NHANSU] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_NHANSU] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_NHANSU] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_NHANSU] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QL_NHANSU] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QL_NHANSU] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_NHANSU] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_NHANSU] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_NHANSU] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_NHANSU] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_NHANSU] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_NHANSU] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_NHANSU] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_NHANSU] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_NHANSU] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_NHANSU] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_NHANSU] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_NHANSU] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_NHANSU] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_NHANSU] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_NHANSU] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_NHANSU] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_NHANSU] SET  MULTI_USER 
GO
ALTER DATABASE [QL_NHANSU] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_NHANSU] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_NHANSU] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_NHANSU] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_NHANSU]
GO
/****** Object:  StoredProcedure [dbo].[dangnhap]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[dangnhap] (@username nvarchar(50), @pass nvarchar(50))
as
begin
select count(*) from NguoiDung
 where ID=@username and pass=@pass
end
GO
/****** Object:  StoredProcedure [dbo].[DuAn_NV]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DuAn_NV](@mada nchar(10))
as begin select A.MaNV,TenNV from NhanVien,PhanCong A where NhanVien.MaNV=A.MaNV and A.MaDA=@mada
end
GO
/****** Object:  StoredProcedure [dbo].[kiemtra_da]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kiemtra_da] (@ma nchar(10))
as select count(*) from DuAn where MaDA=@ma
GO
/****** Object:  StoredProcedure [dbo].[kiemtra_nv]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kiemtra_nv] (@ma nchar(10))
as select count(*) from NhanVien where MaNV=@ma
GO
/****** Object:  StoredProcedure [dbo].[kiemtra_pb]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kiemtra_pb] (@ma nchar(10))
as select count(*) from PhongBan where MaPB=@ma
GO
/****** Object:  StoredProcedure [dbo].[NV_select]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NV_select]
as begin select* from NhanVien end
GO
/****** Object:  StoredProcedure [dbo].[PB_NV]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PB_NV](@ma nchar(10))
as begin select TenPB from PhongBan where MaPB=@ma end
GO
/****** Object:  StoredProcedure [dbo].[PB_select]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[PB_select]
as
begin
select MaPB,TenPB from PhongBan
end
GO
/****** Object:  StoredProcedure [dbo].[Sua_DA]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Sua_DA](@mada nchar(10),@tenda nvarchar(50),@mapb nchar(10),@sogio char(10),@diadiem nvarchar(50))
as begin 
update DuAn set MaDA=@mada,TenDA=@tenda,MaPB=@mapb,DiaDiem=@diadiem,tongsogio=@sogio

end

GO
/****** Object:  StoredProcedure [dbo].[Sua_NV]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sua_NV] @manv nchar(10), @nggs nchar(10),@hoten nvarchar(50),@gioitinh char(3),@diachi nvarchar(50),@ngaysinh datetime,@luong char(10),@phongban nchar(10),@sonv char(3),@email nchar(20),@SDT nchar(10),@Chucvu nchar(10)
as
begin
declare @mapb nchar(10)
set @mapb= (select MaPB from PhongBan where PhongBan.TenPB =@phongban)
 UPDATE NhanVien SET  TenNV=@hoten, NgaySinh = @ngaysinh, GTinh=@gioitinh, DChi = @diachi, Luong = @luong, MaPB=@mapb, NgGS=@nggs,SoNVDuoiQuyen=@sonv,Email=@email,Chucvu=@Chucvu,SDT=@SDT
						   WHERE MaNV = @manv 
end
GO
/****** Object:  StoredProcedure [dbo].[Sua_PB]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sua_PB]( @mapb nchar(10),@tenpb nvarchar(50),@matp nchar(10),@sonv char(3),@ngaync date)
as begin
update PhongBan set TenPB=@tenpb,MaTP=@matp,SoNV=@sonv,Ng_NC=@ngaync where MaPB=@mapb
end
GO
/****** Object:  StoredProcedure [dbo].[ThanNhan_NV]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThanNhan_NV](@ma nchar(10))
as
begin
select TenTN,GioiTinh,Ngaysinh,QuanHe from ThanNhan where MaNV=@ma
end
GO
/****** Object:  StoredProcedure [dbo].[Them_DA]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Them_DA](@mada nchar(10),@tenda nvarchar(50),@mapb nchar(10),@sogio char(10),@diadiem nvarchar(50))
as begin 
insert into DuAn(MaDA,TenDA,MaPB,tongsogio,DiaDiem) values(@mada,@tenda,@mapb,@sogio,@diadiem)
end
GO
/****** Object:  StoredProcedure [dbo].[Them_NhanVien]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Them_NhanVien] @manv nchar(10),@nggs nchar(10),@hoten nvarchar(50),@gioitinh char(3),@diachi nvarchar(50),@ngaysinh datetime,@luong char(10),@phongban nchar(10),@sonv char(3),@email nchar(20),@SDT nchar(10),@Chucvu nchar(10)
as
begin
declare @mapb nchar(10)
set @mapb= (select MaPB from PhongBan where PhongBan.TenPB =@phongban)
if not exists(select MaNV from NhanVien where MaNV=@manv)
INSERT INTO NhanVien(MaNV,TenNV,NgaySinh,GTinh,DChi,Luong,MaPB,NgGS,SoNVDuoiQuyen,SDt,Email,Chucvu) values(@manv,@hoten,@ngaysinh,@gioitinh,@diachi,@luong,@mapb,@nggs,@sonv,@SDT,@email,@Chucvu)
end
GO
/****** Object:  StoredProcedure [dbo].[them_nv]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[them_nv](
    @MaNV	nchar(10),
	@TenNV	nvarchar(50),	
	@NGAYSINH DATETime,
	@GIOITINH	char(3),
	@luong	char(10),
	@dchi nvarchar(50),
	@nggs nchar(10),
	@MAPB	nchar(10),	
	@Sonv	char(3))
AS
BEGIN
INSERT INTO NhanVien(MaNV,TenNV,NgaySinh,GTinh,Luong,DChi,NgGS,MaPB,SoNVDuoiQuyen)
VALUES
(@MaNV,@TenNV,@NGAYSINH,@GIOITINH,@luong,@dchi,@nggs,@MAPB,@Sonv)
END
GO
/****** Object:  StoredProcedure [dbo].[Them_PB]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Them_PB](@mapb nchar(10),@tenpb nvarchar(50),@matp nchar(10),@sonv char(3),@ngaync date)
as begin
insert into PhongBan(MaPB,TenPB,MaTP,SoNV,Ng_NC) values(@mapb,@tenpb,@matp,@sonv,@ngaync)
end
GO
/****** Object:  StoredProcedure [dbo].[them_taikhoan]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[them_taikhoan](@username varchar(50),@pass varchar(50))
as begin
insert into NguoiDung(ID,pass)
values (@username,@pass)
end


GO
/****** Object:  StoredProcedure [dbo].[Xoa_DA]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Xoa_DA](@mada nchar(10))
as begin delete DuAn where MaDA=@mada
end

GO
/****** Object:  StoredProcedure [dbo].[Xoa_NV]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Xoa_NV](@ma nchar(10))
as
begin
delete NhanVien
where MaNV=@ma
end
GO
/****** Object:  StoredProcedure [dbo].[Xoa_PB]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Xoa_PB](@mapb nchar(10))
as
begin
delete NhanVien where MaPB=@mapb
delete PhongBan where MaPB=@mapb
end
GO
/****** Object:  Table [dbo].[DuAn]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DuAn](
	[MaDA] [nchar](10) NOT NULL,
	[TenDA] [nvarchar](50) NOT NULL,
	[MaPB] [nchar](10) NULL,
	[DiaDiem] [nvarchar](50) NULL,
	[tongsogio] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[ID] [varchar](50) NOT NULL,
	[pass] [varchar](50) NOT NULL,
 CONSTRAINT [PK__tblNguoi__3214EC271E7CC50B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NULL,
	[DChi] [nvarchar](50) NULL,
	[GTinh] [char](3) NULL,
	[Luong] [char](10) NULL,
	[MaPB] [nchar](10) NULL,
	[NgGS] [nchar](10) NULL,
	[SoNVDuoiQuyen] [char](3) NULL,
	[Email] [nchar](20) NULL,
	[SDT] [nchar](10) NULL,
	[Chucvu] [nchar](10) NULL,
 CONSTRAINT [PK__NhanVien__2725D70A946C45AB] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhanCong](
	[MaNV] [nchar](10) NOT NULL,
	[MaDA] [nchar](10) NOT NULL,
	[SoGio] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[MaDA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPB] [nchar](10) NOT NULL,
	[TenPB] [nvarchar](50) NULL,
	[MaTP] [nchar](10) NULL,
	[Ng_NC] [date] NULL,
	[SoNV] [char](3) NULL,
 CONSTRAINT [PK__PhongBan__2725E7E48467A28C] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThanNhan]    Script Date: 10/23/2017 11:44:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThanNhan](
	[MaNV] [nchar](10) NOT NULL,
	[TenTN] [nvarchar](50) NOT NULL,
	[GioiTinh] [char](3) NULL,
	[NgaySinh] [date] NULL,
	[QuanHe] [nvarchar](50) NULL,
 CONSTRAINT [PK__ThanNhan__63EA497D2A515351] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[TenTN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [QL_NHANSU] SET  READ_WRITE 
GO
