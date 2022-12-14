USE [MyOrder]
GO
/****** Object:  Table [dbo].[tblChiTietHD]    Script Date: 8/28/2022 1:11:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietHD](
	[MaChiTietHD] [numeric](18, 0) NOT NULL,
	[MaHD] [numeric](18, 0) NOT NULL,
	[MaHang] [varchar](10) NOT NULL,
	[Soluong] [int] NOT NULL,
 CONSTRAINT [PK_tblChiTietHD] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHoadon]    Script Date: 8/28/2022 1:11:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoadon](
	[MaHD] [numeric](18, 0) NOT NULL,
	[MaKH] [varchar](10) NOT NULL,
	[NgayHD] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Hoadon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKhachHang]    Script Date: 8/28/2022 1:11:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhachHang](
	[MaKH] [varchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[GT] [bit] NOT NULL,
	[Diachi] [nvarchar](50) NOT NULL,
	[NgaySinh] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_tblKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMatHang]    Script Date: 8/28/2022 1:11:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMatHang](
	[MaHang] [varchar](10) NOT NULL,
	[TenHang] [nvarchar](50) NOT NULL,
	[DVT] [varchar](50) NOT NULL,
	[Gia] [real] NOT NULL,
 CONSTRAINT [PK_tblMatHang] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 8/28/2022 1:11:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[Username] [nvarchar](50) NOT NULL,
	[Pass] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'K01', 2)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'R02', 1)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'M01', 3)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'M02', 1)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'a', 1)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), N'M02', 1)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), N'M02', 2)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(11 AS Numeric(18, 0)), CAST(7 AS Numeric(18, 0)), N'R01', 2)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(12 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)), N'K02', 1)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(13 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), N'M01', 2)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(14 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)), N'R02', 1)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(18 AS Numeric(18, 0)), CAST(14 AS Numeric(18, 0)), N'K01', 1)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(19 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), N'K01', 9)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(20 AS Numeric(18, 0)), CAST(19 AS Numeric(18, 0)), N'a', 1)
INSERT [dbo].[tblChiTietHD] ([MaChiTietHD], [MaHD], [MaHang], [Soluong]) VALUES (CAST(23 AS Numeric(18, 0)), CAST(22 AS Numeric(18, 0)), N'a', 2)
GO
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(1 AS Numeric(18, 0)), N'KH01', CAST(N'2022-02-02T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(2 AS Numeric(18, 0)), N'KH02', CAST(N'2022-01-01T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(3 AS Numeric(18, 0)), N'KH03', CAST(N'2022-09-08T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(4 AS Numeric(18, 0)), N'KH04', CAST(N'2022-07-07T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(5 AS Numeric(18, 0)), N'KH01', CAST(N'2022-01-04T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(6 AS Numeric(18, 0)), N'KH03', CAST(N'2022-02-02T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(7 AS Numeric(18, 0)), N'KH05', CAST(N'2022-04-04T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(8 AS Numeric(18, 0)), N'KH08', CAST(N'2022-03-04T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(9 AS Numeric(18, 0)), N'KH09', CAST(N'2022-01-02T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(10 AS Numeric(18, 0)), N'KH07', CAST(N'2022-08-07T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(11 AS Numeric(18, 0)), N'KH01', CAST(N'2022-08-24T21:48:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(13 AS Numeric(18, 0)), N'KH02', CAST(N'2022-08-24T22:53:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(14 AS Numeric(18, 0)), N'2', CAST(N'2022-08-24T22:55:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(16 AS Numeric(18, 0)), N'a', CAST(N'2022-08-25T14:59:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(18 AS Numeric(18, 0)), N'gg', CAST(N'2022-08-25T16:12:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(19 AS Numeric(18, 0)), N'gg', CAST(N'2022-08-25T16:05:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(20 AS Numeric(18, 0)), N'jj', CAST(N'2022-08-25T16:12:00' AS SmallDateTime))
INSERT [dbo].[tblHoadon] ([MaHD], [MaKH], [NgayHD]) VALUES (CAST(22 AS Numeric(18, 0)), N'll', CAST(N'2022-08-25T16:18:00' AS SmallDateTime))
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'2', N'Văn Mai Hương', 0, N'HN', CAST(N'1999-12-11T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'3', N'Hoàng Thanh Chính', 1, N'HN', CAST(N'2001-11-12T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'4', N'Nguyễn Hà', 1, N'ND', CAST(N'1982-01-01T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'9', N'hh', 0, N'hhh', CAST(N'2022-08-23T03:38:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'gg', N'gg', 1, N'gg', CAST(N'2022-08-25T16:05:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'hh', N'hh', 1, N'hh', CAST(N'2022-08-25T16:10:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'jj', N'jj', 0, N'jj', CAST(N'2022-08-25T16:13:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'KH02', N'Lưu Tùng Lâm', 1, N'LC', CAST(N'1993-12-12T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'KH03', N'Nguyễn Văn Chiến', 1, N'DN', CAST(N'2001-11-01T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'KH04', N'Vũ Văn Thanh', 1, N'HP', CAST(N'1991-01-01T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'KH05', N'Hoàng Thị Hồng', 0, N'HCM', CAST(N'2002-02-02T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'KH06', N'Nguyễn Thảo Linh', 0, N'NT', CAST(N'2000-07-07T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'KH08', N'Phạm Thanh Hà', 0, N'LS', CAST(N'1998-01-08T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'KH09', N'Trần Văn Trung', 1, N'CM', CAST(N'2000-04-04T00:00:00' AS SmallDateTime))
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [GT], [Diachi], [NgaySinh]) VALUES (N'll', N'll', 1, N'll', CAST(N'2022-08-25T16:22:00' AS SmallDateTime))
GO
INSERT [dbo].[tblMatHang] ([MaHang], [TenHang], [DVT], [Gia]) VALUES (N'a', N'a', N'Chiec', 10000)
INSERT [dbo].[tblMatHang] ([MaHang], [TenHang], [DVT], [Gia]) VALUES (N'K01', N'Bàn phím', N'Chiec', 200000)
INSERT [dbo].[tblMatHang] ([MaHang], [TenHang], [DVT], [Gia]) VALUES (N'K02', N'Laptop', N'Chiec', 120000)
INSERT [dbo].[tblMatHang] ([MaHang], [TenHang], [DVT], [Gia]) VALUES (N'M01', N'Chuột quang', N'Con', 120000)
INSERT [dbo].[tblMatHang] ([MaHang], [TenHang], [DVT], [Gia]) VALUES (N'M02', N'Màn hình', N'Cái', 2000000)
INSERT [dbo].[tblMatHang] ([MaHang], [TenHang], [DVT], [Gia]) VALUES (N'R01', N'Ram Kington 4GB', N'Thanh', 300000)
INSERT [dbo].[tblMatHang] ([MaHang], [TenHang], [DVT], [Gia]) VALUES (N'R02', N'Cuong luc vip', N' Cai', 1000000)
GO
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'admin', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'aococtay', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'ban', 1234)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'daibang', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'gau', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'gg', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'ghe', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'hoc', 1111)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'mangxa', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'prn', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'pro', 2222)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'sa', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'sutu', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'tuanvm', 123)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'user', 1234)
INSERT [dbo].[tblUser] ([Username], [Pass]) VALUES (N'vip', 1234)
GO
