USE [master]
GO
/****** Object:  Database [QLPHONGKHAM]    Script Date: 1/7/2019 9:39:02 AM ******/
CREATE DATABASE [QLPHONGKHAM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLPHONGKHAM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLPHONGKHAM.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLPHONGKHAM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLPHONGKHAM_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLPHONGKHAM] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLPHONGKHAM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLPHONGKHAM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLPHONGKHAM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLPHONGKHAM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLPHONGKHAM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLPHONGKHAM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLPHONGKHAM] SET  MULTI_USER 
GO
ALTER DATABASE [QLPHONGKHAM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLPHONGKHAM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLPHONGKHAM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLPHONGKHAM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLPHONGKHAM] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLPHONGKHAM]
GO
/****** Object:  Table [dbo].[BENHNHAN]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BENHNHAN](
	[MaBenhNhan] [char](10) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[CMND] [varchar](12) NULL,
	[NgaySinh] [char](8) NULL,
	[GioiTinh] [bit] NULL,
	[SoDienThoai] [varchar](11) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_BENHNHAN] PRIMARY KEY CLUSTERED 
(
	[MaBenhNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHITIETDONTHUOC]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHITIETDONTHUOC](
	[MaDonThuoc] [char](10) NOT NULL,
	[MaThuoc] [char](10) NOT NULL,
	[SoLuong] [int] NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_CHITIETDONTHUOC] PRIMARY KEY CLUSTERED 
(
	[MaDonThuoc] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DONTHUOC]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DONTHUOC](
	[MaDonThuoc] [char](10) NOT NULL,
	[MaHoSo] [char](10) NULL,
	[NgayLap] [char](8) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_DONTHUOC] PRIMARY KEY CLUSTERED 
(
	[MaDonThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOSOBENHAN]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOSOBENHAN](
	[MaHoSo] [char](10) NOT NULL,
	[MaHoSoTruoc] [char](10) NULL,
	[MaHoSoGoc] [char](10) NULL,
	[MaLoaiHoSo] [char](10) NULL,
	[MaBenhNhan] [char](10) NOT NULL,
	[MaNguoiTN] [char](10) NOT NULL,
	[NgayTiepNhan] [char](8) NULL,
	[YeuCauKham] [nvarchar](250) NULL,
	[TrieuChung] [nvarchar](250) NULL,
	[NgayKham] [char](8) NULL,
	[SoThuTu] [int] NULL,
	[MaPhongKham] [char](10) NULL,
	[MaBacSi] [char](10) NULL,
	[ChuanDoan] [ntext] NULL,
	[CoKeDon] [bit] NULL,
 CONSTRAINT [PK_HoSoBenhAn] PRIMARY KEY CLUSTERED 
(
	[MaHoSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KETQUAXETNGHIEM]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KETQUAXETNGHIEM](
	[MaHoSo] [char](10) NOT NULL,
	[MaXetNghiem] [char](10) NOT NULL,
	[MaBacSi] [char](10) NOT NULL,
	[NgayXetNghiem] [char](8) NULL,
	[KetQua] [ntext] NULL,
	[ThanhToan] [bit] NULL,
	[TongChiPhi] [decimal](12, 0) NULL,
 CONSTRAINT [PK_KETQUAXETNGHIEM] PRIMARY KEY CLUSTERED 
(
	[MaHoSo] ASC,
	[MaXetNghiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAIHOSO]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAIHOSO](
	[MaLoaiHoSo] [char](10) NOT NULL,
	[TenLoaiHoSo] [nvarchar](250) NULL,
 CONSTRAINT [PK_LOAIHOSO_1] PRIMARY KEY CLUSTERED 
(
	[MaLoaiHoSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAINHANVIEN]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAINHANVIEN](
	[MaLoaiNV] [char](10) NOT NULL,
	[TenLoaiNV] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_LoaiNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LUONCONGVIEC]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LUONCONGVIEC](
	[MaHoSo] [char](10) NOT NULL,
	[NodeHienTai] [char](5) NULL,
	[TiepNhan] [bit] NULL,
	[KhamBenh] [bit] NULL,
	[XetNghiem] [bit] NULL,
 CONSTRAINT [PK_LUONCONGVIEC] PRIMARY KEY CLUSTERED 
(
	[MaHoSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [char](10) NOT NULL,
	[HoTenNV] [nvarchar](50) NOT NULL,
	[NgaySinh] [char](8) NULL,
	[CMND] [varchar](12) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SoDienThoai] [varchar](11) NULL,
	[Email] [nvarchar](250) NULL,
	[MaSoThue] [varchar](13) NULL,
	[SoTaiKhoan] [varchar](15) NULL,
	[MaLoaiNV] [char](10) NULL,
	[MaPhong] [char](10) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHONG](
	[MaPhong] [char](10) NOT NULL,
	[TenPhong] [nvarchar](250) NOT NULL,
	[ChuyenKhoa] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_PHONG] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[MaTaiKhoan] [char](10) NOT NULL,
	[TenDangNhap] [varchar](20) NULL,
	[MatKhau] [char](32) NULL,
	[NgayThayDoi] [char](8) NULL,
	[MaNhanVien] [char](10) NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THANHTOAN]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[THANHTOAN](
	[MaThanhToan] [char](10) NOT NULL,
	[MaHoSo] [char](10) NOT NULL,
	[ChiPhiKham] [decimal](12, 0) NULL,
	[ChiPhiXetNghiem] [decimal](12, 0) NULL,
	[TongChiPhi] [decimal](12, 0) NULL,
	[NhanVienThu] [char](10) NULL,
	[NgayThu] [char](8) NULL,
 CONSTRAINT [PK_THANHTOAN] PRIMARY KEY CLUSTERED 
(
	[MaThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THUOC]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[THUOC](
	[MaThuoc] [char](10) NOT NULL,
	[TenThuoc] [nvarchar](50) NULL,
	[ChiDinh] [nvarchar](250) NULL,
	[ChongChiDinh] [nvarchar](250) NULL,
 CONSTRAINT [PK_THUOC] PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRANGTHAIPHONG]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRANGTHAIPHONG](
	[MaPhong] [char](10) NOT NULL,
	[NgayKham] [char](8) NOT NULL,
	[SttCaoNhat] [int] NULL,
 CONSTRAINT [PK_TRANGTHAIPHONG] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC,
	[NgayKham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[XETNGHIEM]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[XETNGHIEM](
	[MaXetNghiem] [char](10) NOT NULL,
	[TenXetNghiem] [nvarchar](250) NOT NULL,
	[MaPhong] [char](10) NULL,
	[ChiPhi] [decimal](12, 0) NULL,
 CONSTRAINT [PK_XETNGHIEM] PRIMARY KEY CLUSTERED 
(
	[MaXetNghiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CHITIETDONTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDONTHUOC_DONTHUOC] FOREIGN KEY([MaDonThuoc])
REFERENCES [dbo].[DONTHUOC] ([MaDonThuoc])
GO
ALTER TABLE [dbo].[CHITIETDONTHUOC] CHECK CONSTRAINT [FK_CHITIETDONTHUOC_DONTHUOC]
GO
ALTER TABLE [dbo].[CHITIETDONTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDONTHUOC_THUOC] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[THUOC] ([MaThuoc])
GO
ALTER TABLE [dbo].[CHITIETDONTHUOC] CHECK CONSTRAINT [FK_CHITIETDONTHUOC_THUOC]
GO
ALTER TABLE [dbo].[DONTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_DONTHUOC_HoSoBenhAn] FOREIGN KEY([MaHoSo])
REFERENCES [dbo].[HOSOBENHAN] ([MaHoSo])
GO
ALTER TABLE [dbo].[DONTHUOC] CHECK CONSTRAINT [FK_DONTHUOC_HoSoBenhAn]
GO
ALTER TABLE [dbo].[HOSOBENHAN]  WITH CHECK ADD  CONSTRAINT [FK_HOSOBENHAN_BENHNHAN] FOREIGN KEY([MaBenhNhan])
REFERENCES [dbo].[BENHNHAN] ([MaBenhNhan])
GO
ALTER TABLE [dbo].[HOSOBENHAN] CHECK CONSTRAINT [FK_HOSOBENHAN_BENHNHAN]
GO
ALTER TABLE [dbo].[HOSOBENHAN]  WITH CHECK ADD  CONSTRAINT [FK_HOSOBENHAN_LOAIHOSO] FOREIGN KEY([MaLoaiHoSo])
REFERENCES [dbo].[LOAIHOSO] ([MaLoaiHoSo])
GO
ALTER TABLE [dbo].[HOSOBENHAN] CHECK CONSTRAINT [FK_HOSOBENHAN_LOAIHOSO]
GO
ALTER TABLE [dbo].[HOSOBENHAN]  WITH CHECK ADD  CONSTRAINT [FK_HOSOBENHAN_NhanVien] FOREIGN KEY([MaNguoiTN])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[HOSOBENHAN] CHECK CONSTRAINT [FK_HOSOBENHAN_NhanVien]
GO
ALTER TABLE [dbo].[KETQUAXETNGHIEM]  WITH CHECK ADD  CONSTRAINT [FK_KETQUAXETNGHIEM_HoSoBenhAn] FOREIGN KEY([MaHoSo])
REFERENCES [dbo].[HOSOBENHAN] ([MaHoSo])
GO
ALTER TABLE [dbo].[KETQUAXETNGHIEM] CHECK CONSTRAINT [FK_KETQUAXETNGHIEM_HoSoBenhAn]
GO
ALTER TABLE [dbo].[KETQUAXETNGHIEM]  WITH CHECK ADD  CONSTRAINT [FK_KETQUAXETNGHIEM_NhanVien] FOREIGN KEY([MaBacSi])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[KETQUAXETNGHIEM] CHECK CONSTRAINT [FK_KETQUAXETNGHIEM_NhanVien]
GO
ALTER TABLE [dbo].[KETQUAXETNGHIEM]  WITH CHECK ADD  CONSTRAINT [FK_KETQUAXETNGHIEM_XETNGHIEM] FOREIGN KEY([MaXetNghiem])
REFERENCES [dbo].[XETNGHIEM] ([MaXetNghiem])
GO
ALTER TABLE [dbo].[KETQUAXETNGHIEM] CHECK CONSTRAINT [FK_KETQUAXETNGHIEM_XETNGHIEM]
GO
ALTER TABLE [dbo].[LUONCONGVIEC]  WITH CHECK ADD  CONSTRAINT [FK_LUONCONGVIEC_HoSoBenhAn] FOREIGN KEY([MaHoSo])
REFERENCES [dbo].[HOSOBENHAN] ([MaHoSo])
GO
ALTER TABLE [dbo].[LUONCONGVIEC] CHECK CONSTRAINT [FK_LUONCONGVIEC_HoSoBenhAn]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_LOAINHANVIEN] FOREIGN KEY([MaLoaiNV])
REFERENCES [dbo].[LOAINHANVIEN] ([MaLoaiNV])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_LOAINHANVIEN]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_PHONG] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_PHONG]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TAIKHOAN_NhanVien]
GO
ALTER TABLE [dbo].[THANHTOAN]  WITH CHECK ADD  CONSTRAINT [FK_THANHTOAN_HoSoBenhAn] FOREIGN KEY([MaHoSo])
REFERENCES [dbo].[HOSOBENHAN] ([MaHoSo])
GO
ALTER TABLE [dbo].[THANHTOAN] CHECK CONSTRAINT [FK_THANHTOAN_HoSoBenhAn]
GO
ALTER TABLE [dbo].[TRANGTHAIPHONG]  WITH CHECK ADD  CONSTRAINT [FK_TRANGTHAIPHONG_PHONG] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[TRANGTHAIPHONG] CHECK CONSTRAINT [FK_TRANGTHAIPHONG_PHONG]
GO
ALTER TABLE [dbo].[XETNGHIEM]  WITH CHECK ADD  CONSTRAINT [FK_XETNGHIEM_PHONG] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[XETNGHIEM] CHECK CONSTRAINT [FK_XETNGHIEM_PHONG]
GO
/****** Object:  StoredProcedure [dbo].[GetDonThuoc]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetDonThuoc]
as 
SELECT        CHITIETDONTHUOC.MaDonThuoc, DONTHUOC.MaHoSo, DONTHUOC.MaDonThuoc AS Expr1, CHITIETDONTHUOC.MaThuoc, THUOC.TenThuoc, 
                         CHITIETDONTHUOC.SoLuong, CHITIETDONTHUOC.GhiChu
FROM            CHITIETDONTHUOC INNER JOIN
                         DONTHUOC ON CHITIETDONTHUOC.MaDonThuoc = DONTHUOC.MaDonThuoc INNER JOIN
                         THUOC ON CHITIETDONTHUOC.MaThuoc = THUOC.MaThuoc
GO
/****** Object:  StoredProcedure [dbo].[GetThanhToan]    Script Date: 1/7/2019 9:39:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetThanhToan]
@MaHS char(10)
as
SELECT        KETQUAXETNGHIEM.MaHoSo, KETQUAXETNGHIEM.MaXetNghiem, XETNGHIEM.MaXetNghiem AS Expr1, XETNGHIEM.TenXetNghiem, 
                         KETQUAXETNGHIEM.TongChiPhi, KETQUAXETNGHIEM.ThanhToan
FROM            KETQUAXETNGHIEM INNER JOIN
                         XETNGHIEM ON KETQUAXETNGHIEM.MaXetNghiem = XETNGHIEM.MaXetNghiem
Where			KETQUAXETNGHIEM.ThanhToan = 1 and KETQUAXETNGHIEM.MaHoSo = @MaHS
GO
USE [master]
GO
ALTER DATABASE [QLPHONGKHAM] SET  READ_WRITE 
GO
