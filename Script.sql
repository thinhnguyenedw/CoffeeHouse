USE [master]
GO
/****** Object:  Database [btlDatabase]    Script Date: 04/05/2024 9:37:38 CH ******/
CREATE DATABASE [btlDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'btlDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\btlDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'btlDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\btlDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [btlDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [btlDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [btlDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [btlDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [btlDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [btlDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [btlDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [btlDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [btlDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [btlDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [btlDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [btlDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [btlDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [btlDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [btlDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [btlDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [btlDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [btlDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [btlDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [btlDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [btlDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [btlDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [btlDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [btlDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [btlDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [btlDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [btlDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [btlDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [btlDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [btlDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [btlDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [btlDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'btlDatabase', N'ON'
GO
ALTER DATABASE [btlDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [btlDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [btlDatabase]
GO
/****** Object:  Table [dbo].[HOA_DON]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOA_DON](
	[MaHD] [varchar](10) NOT NULL,
	[MaNV] [varchar](5) NULL,
	[NgayLap] [date] NULL,
	[Ban] [varchar](3) NULL,
	[TongTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_Hoadon]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_Hoadon] as
SELECT [MaHD] as [Mã hoá đơn]
      ,[MaNV] as [Mã nhân viên]
      ,[NgayLap] as [Ngày lập]
      ,[Ban] as [Bàn]
      ,[TongTien] as [Tổng tiền]
  FROM [btlDatabase].[dbo].[HOA_DON]
GO
/****** Object:  Table [dbo].[SAN_PHAM]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAN_PHAM](
	[MaSP] [varchar](6) NOT NULL,
	[TenSP] [nvarchar](40) NOT NULL,
	[MaLoai] [varchar](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHI_TIET_HOA_DON]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHI_TIET_HOA_DON](
	[MaHD] [varchar](10) NOT NULL,
	[MaSP] [varchar](6) NOT NULL,
	[MaSize] [varchar](1) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_hoadon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSP] ASC,
	[MaSize] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_ChitietHoadon]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_ChitietHoadon]
as
SELECT  [MaHD] as [Mã hoá đơn]
      ,[CHI_TIET_HOA_DON].MaSP as [Mã sản phẩm]
	  ,TenSP as [Tên sản phẩm]
      ,[MaSize] as [Size]
      ,[SoLuong] as [Số lượng]
      ,[ThanhTien] as [Thành tiền]
  FROM [btlDatabase].[dbo].[CHI_TIET_HOA_DON] inner join SAN_PHAM on SAN_PHAM.MaSP=CHI_TIET_HOA_DON.MaSP
GO
/****** Object:  View [dbo].[v_HoadonThanhtien]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_HoadonThanhtien]
as
SELECT  
v_ChitietHoadon.[Mã hoá đơn],
[Mã nhân viên],
[Ngày lập],
[Bàn],
[Mã sản phẩm],
Size,
[Số lượng],
[Thành tiền],
[Tổng tiền]
  FROM v_ChitietHoadon inner join v_Hoadon on v_ChitietHoadon.[Mã hoá đơn]=v_Hoadon.[Mã hoá đơn]
GO
/****** Object:  View [dbo].[v_Dondatao]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_Dondatao]
as
select MaHD from HOA_DON
GO
/****** Object:  View [dbo].[v_NhanvienHoadon]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_NhanvienHoadon]
AS
select MaHD as [Mã hoá đơn], MaNV as [Mã nhân viên], Ban as [Bàn] , NgayLap as [Ngày lập], TongTien as [Tổng tiền] from HOA_DON
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [varchar](5) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [varchar](10) NULL,
	[NgayVaoLam] [date] NULL,
	[VaiTro] [varchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_NV]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create view [dbo].[v_NV]
  as
  select * from NHANVIEN
GO
/****** Object:  Table [dbo].[TAI_KHOAN]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAI_KHOAN](
	[TaiKhoan] [varchar](20) NOT NULL,
	[MatKhau] [varchar](20) NOT NULL,
	[MaNV] [varchar](5) NULL,
	[VaiTro] [varchar](2) NULL,
	[NgayLap] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_Account]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_Account]
AS
SELECT TaiKhoan as [Tên đăng nhập], MatKhau as [Mật khẩu], TAI_KHOAN.MaNV as [Mã nhân viên], NHANVIEN.HoTen as [Tên nhân viên], VaiTro as [Vai trò], NgaySinh as [Ngày sinh], NgayLap as [Ngày lập]
from TAI_KHOAN inner join NHANVIEN on TAI_KHOAN.MaNV=NHANVIEN.MaNV
GO
/****** Object:  Table [dbo].[THUC_DON]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUC_DON](
	[MaSP] [varchar](6) NOT NULL,
	[Size] [varchar](1) NULL,
	[DonViTinh] [nvarchar](5) NOT NULL,
	[DonGia] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_Hanghoa]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE VIEW [dbo].[v_Hanghoa] AS
SELECT 
    SAN_PHAM.MaSP AS [Mã sản phẩm], 
    MaLoai AS [Mã loại], 
    TenSP AS [Tên sản phẩm], 
    Size AS [Size], 
    DonViTinh AS [Đơn vị tính], 
    DonGia AS [Đơn giá]
FROM 
    SAN_PHAM 
INNER JOIN 
    THUC_DON ON SAN_PHAM.MaSP = THUC_DON.MaSP;
GO
/****** Object:  Table [dbo].[BAN]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAN](
	[Ban] [varchar](3) NOT NULL,
	[MoTa] [nvarchar](9) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Ban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KICH_CO]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KICH_CO](
	[Size] [varchar](1) NOT NULL,
	[MoTa] [varchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Size] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAI_SP]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI_SP](
	[MaLoai] [varchar](6) NOT NULL,
	[TenLoai] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nv]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nv](
	[manv] [int] NULL,
	[tennv] [nvarchar](20) NULL,
	[mst] [nvarchar](10) NULL,
UNIQUE NONCLUSTERED 
(
	[manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[mst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VI_TRI]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VI_TRI](
	[MaViTri] [varchar](2) NOT NULL,
	[TenViTri] [nvarchar](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaViTri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HOA_DON] ADD  DEFAULT (getdate()) FOR [NgayLap]
GO
ALTER TABLE [dbo].[NHANVIEN] ADD  DEFAULT (getdate()) FOR [NgayVaoLam]
GO
ALTER TABLE [dbo].[TAI_KHOAN] ADD  DEFAULT (getdate()) FOR [NgayLap]
GO
ALTER TABLE [dbo].[CHI_TIET_HOA_DON]  WITH CHECK ADD FOREIGN KEY([MaSize])
REFERENCES [dbo].[KICH_CO] ([Size])
GO
ALTER TABLE [dbo].[CHI_TIET_HOA_DON]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[THUC_DON] ([MaSP])
GO
ALTER TABLE [dbo].[HOA_DON]  WITH CHECK ADD FOREIGN KEY([Ban])
REFERENCES [dbo].[BAN] ([Ban])
GO
ALTER TABLE [dbo].[HOA_DON]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([VaiTro])
REFERENCES [dbo].[VI_TRI] ([MaViTri])
GO
ALTER TABLE [dbo].[SAN_PHAM]  WITH CHECK ADD FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LOAI_SP] ([MaLoai])
GO
ALTER TABLE [dbo].[TAI_KHOAN]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[THUC_DON]  WITH CHECK ADD FOREIGN KEY([Size])
REFERENCES [dbo].[KICH_CO] ([Size])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [checkGT] CHECK  (([GioiTinh]=N'Nữ' OR [GioiTinh]=N'Nam'))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [checkGT]
GO
ALTER TABLE [dbo].[TAI_KHOAN]  WITH CHECK ADD CHECK  (([VaiTro]='AD' OR [VaiTro]='NV'))
GO
ALTER TABLE [dbo].[THUC_DON]  WITH CHECK ADD CHECK  (([DonGia]>=(0)))
GO
ALTER TABLE [dbo].[VI_TRI]  WITH CHECK ADD CHECK  (([MaViTri]='PV' OR [MaViTri]='PC' OR [MaViTri]='TN'))
GO
/****** Object:  StoredProcedure [dbo].[addChitietHoadon]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[addChitietHoadon]
  @mahd nvarchar(10), @masp nvarchar(6), @size nvarchar(1), @soluong int
  as
  begin
  insert into CHI_TIET_HOA_DON (MaHD, MaSP, MaSize, SoLuong) values (@mahd, @masp, @size, @soluong)
  end
GO
/****** Object:  StoredProcedure [dbo].[addHoadon]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[addHoadon]
@mahd varchar(10), @manv varchar(5), @ban varchar(3)
as
insert into HOA_DON(MaHD, MaNV, Ban) Values(@mahd, @manv, @ban)
GO
/****** Object:  StoredProcedure [dbo].[addNVMST]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[addNVMST]
  @manv nvarchar(10), @mast nvarchar(10), @tennv nvarchar(10), @ngaysinh date
  as
  insert into NHANVIEN (MaNV, mathue, HoTen, NgaySinh) values(@manv, @mast, @tennv, @ngaysinh)
GO
/****** Object:  StoredProcedure [dbo].[checkMST]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[checkMST]
  @mast1 nvarchar(10), @mast2 nvarchar(10)
  as
  select * from NHANVIEN
  where mathue>@mast1 and mathue<@mast2 
GO
/****** Object:  StoredProcedure [dbo].[layMaNV]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[layMaNV]
@taikhoan nvarchar(5)
as
begin
select MaNV from TAI_KHOAN
where TaiKhoan=@taikhoan
end
GO
/****** Object:  StoredProcedure [dbo].[searchHoadon]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[searchHoadon]
@mahd varchar(6)
as
begin
select * from v_HoadonThanhtien
where [Mã hoá đơn] like @mahd
end
GO
/****** Object:  StoredProcedure [dbo].[selectSize]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[selectSize]
  @masp nvarchar(6)
  as
  begin
  select Size from v_Hanghoa where [Mã sản phẩm]=@masp
  end
GO
/****** Object:  StoredProcedure [dbo].[suaAccount]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[suaAccount]
    @acc varchar(20),
    @pass varchar(20),
    @vaitro varchar(2),
    @manv varchar(5),
    @tennv nvarchar(50),
    @ngaysinh date
AS
BEGIN
    UPDATE TAI_KHOAN
    SET MatKhau = @pass, VaiTro = @vaitro
    WHERE TaiKhoan = @acc;

    UPDATE NHANVIEN
    SET HoTen = @tennv, NgaySinh = @ngaysinh
    WHERE MaNV = @manv;
END
GO
/****** Object:  StoredProcedure [dbo].[suaChitietHoadon]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   create proc [dbo].[suaChitietHoadon]
  @mahd nvarchar(10), @masp nvarchar(6), @size nvarchar(1),  @soluong int
  as begin
  update CHI_TIET_HOA_DON set SoLuong=@soluong where MaHD=@mahd and MaSP=@masp and MaSize=@size
  end
GO
/****** Object:  StoredProcedure [dbo].[suaEmployee]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[suaEmployee]
    @manv varchar(5),
    @hoten nvarchar(50),
    @ngaysinh date,
    @gioitinh nvarchar(3),
    @diachi nvarchar(50),
	@phone varchar(10),
    @mavtri varchar(2)
AS
BEGIN
    UPDATE NHANVIEN
    SET MaNV=@manv, HoTen=@hoten, NgaySinh=@ngaysinh, GioiTinh=@gioitinh, DiaChi=@diachi, SoDienThoai=@phone, MaViTri=@mavtri
    WHERE MaNV=@manv;
END
GO
/****** Object:  StoredProcedure [dbo].[suaHanghoa]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[suaHanghoa] 
@masp nvarchar(6), @tensp nvarchar(40), @maloai nvarchar(6), @size varchar(1), @dvtinh nvarchar(5), @dongia float
AS
begin
update SAN_PHAM  set TenSP=@tensp, MaLoai=@maloai where MaSP=@masp;
update THUC_DON set Size=@size, DonViTinh=@dvtinh, DonGia=@dongia where MaSP=@masp
end
GO
/****** Object:  StoredProcedure [dbo].[suanv]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[suanv]
@manv nvarchar(10), @mast nvarchar(10), @tennv nvarchar(10), @ngaysinh date
as
update NHANVIEN set mathue=@mast, HoTen=@tennv, NgaySinh=@ngaysinh
where MaNV=@manv
GO
/****** Object:  StoredProcedure [dbo].[themAccount]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[themAccount]
    @acc varchar(20), @pass varchar(20), @manv varchar(5), @tennv nvarchar(50), @ngaysinh date, @vaitro varchar(2)
  as
  begin
  insert into NHANVIEN(MaNV, HoTen, NgaySinh) values (@manv, @tennv, @ngaysinh)
  insert into TAI_KHOAN(TaiKhoan, MatKhau, MaNV, VaiTro) values (@acc, @pass, @manv, @vaitro)
  end
GO
/****** Object:  StoredProcedure [dbo].[themHanghoa]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[themHanghoa] 
@masp nvarchar(6), @tensp nvarchar(40), @maloai nvarchar(6), @size varchar(1), @dvtinh nvarchar(5), @dongia float
AS
begin
insert into SAN_PHAM (MaSP, TenSP, MaLoai) values (@masp, @tensp, @maloai);
insert into THUC_DON (MaSP, Size, DonViTinh, DonGia) values (@masp, @size, @dvtinh, @dongia);
end
GO
/****** Object:  StoredProcedure [dbo].[xemChitietBill]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[xemChitietBill]
@mahd varchar(10)
AS
BEGIN
Select * from v_ChitietHoadon
where [Mã hoá đơn]=@mahd
END
GO
/****** Object:  StoredProcedure [dbo].[xoaAccount]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[xoaAccount]
    @acc varchar(20), @manv nvarchar(5)
AS
BEGIN
    DELETE FROM TAI_KHOAN
    WHERE TaiKhoan = @acc;

    DELETE FROM NHANVIEN
    WHERE MaNV=@manv
END
GO
/****** Object:  StoredProcedure [dbo].[xoaChitietHoadon]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[xoaChitietHoadon]
  @mahd nvarchar(10), @masp nvarchar(6), @size nvarchar(1)
  as begin
  delete from CHI_TIET_HOA_DON where MaHD=@mahd and MaSP=@masp and MaSize=@size
  end
GO
/****** Object:  StoredProcedure [dbo].[xoaHanghoa]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[xoaHanghoa]
    @masp nvarchar(6)
AS
BEGIN
    DELETE FROM THUC_DON
    WHERE MaSP = @masp;

    DELETE FROM SAN_PHAM
    WHERE MaSP = @masp;
END
GO
/****** Object:  StoredProcedure [dbo].[xoaHoadon]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[xoaHoadon]
@mahd varchar(10)
as
delete from HOA_DON where MaHD=@mahd;
delete from CHI_TIET_HOA_DON where MaHD=@mahd;
GO
/****** Object:  StoredProcedure [dbo].[xoanv]    Script Date: 04/05/2024 9:37:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[xoanv]
@manv nvarchar(10)
as
delete NHANVIEN where MaNV=@manv
GO
USE [master]
GO
ALTER DATABASE [btlDatabase] SET  READ_WRITE 
GO
