USE [master]
GO
/****** Object:  Database [EgitimSistemiDemo]    Script Date: 12/22/2019 9:26:44 PM ******/
CREATE DATABASE [EgitimSistemiDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EgitimSistemiDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EgitimSistemiDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EgitimSistemiDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EgitimSistemiDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EgitimSistemiDemo] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EgitimSistemiDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EgitimSistemiDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EgitimSistemiDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EgitimSistemiDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EgitimSistemiDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EgitimSistemiDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EgitimSistemiDemo] SET  MULTI_USER 
GO
ALTER DATABASE [EgitimSistemiDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EgitimSistemiDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EgitimSistemiDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EgitimSistemiDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EgitimSistemiDemo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EgitimSistemiDemo] SET QUERY_STORE = OFF
GO
USE [EgitimSistemiDemo]
GO
/****** Object:  Table [dbo].[Ders]    Script Date: 12/22/2019 9:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Ders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DersSinif]    Script Date: 12/22/2019 9:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DersSinif](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DersId] [int] NOT NULL,
	[SinifId] [int] NOT NULL,
 CONSTRAINT [PK_DersSinif] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenci]    Script Date: 12/22/2019 9:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenci](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[No] [nvarchar](50) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[Gsm] [nvarchar](50) NULL,
	[Eposta] [nvarchar](100) NULL,
	[Durum] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Ogrenci] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciDers]    Script Date: 12/22/2019 9:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciDers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OgrenciId] [int] NOT NULL,
	[DersId] [int] NOT NULL,
 CONSTRAINT [PK_OgrenciDers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sinif]    Script Date: 12/22/2019 9:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sinif](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Kontenjan] [tinyint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Sinif] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ders] ON 

INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (1, N'matematik', CAST(N'2019-10-27T23:49:22.853' AS DateTime), CAST(N'2019-12-12T13:42:22.537' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (2, N'Türkçe', CAST(N'2019-10-27T23:49:44.200' AS DateTime), CAST(N'2019-12-12T10:35:15.317' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (3, N'Kimya', CAST(N'2019-10-27T23:50:33.743' AS DateTime), CAST(N'2019-10-27T23:50:33.743' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (4, N'Coğrafya', CAST(N'2019-10-28T02:20:08.420' AS DateTime), CAST(N'2019-10-28T02:21:02.443' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (5, N'ccccc', CAST(N'2019-12-09T22:11:41.507' AS DateTime), CAST(N'2019-12-12T10:27:50.750' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (6, N'string', CAST(N'2019-12-09T22:20:43.067' AS DateTime), CAST(N'2019-12-09T23:30:54.183' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (7, N'string', CAST(N'2019-12-09T22:20:51.997' AS DateTime), CAST(N'2019-12-09T23:30:51.030' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (8, N'string', CAST(N'2019-12-09T23:22:15.083' AS DateTime), CAST(N'2019-12-09T23:30:43.050' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (9, N'string', CAST(N'2019-12-09T23:27:32.850' AS DateTime), CAST(N'2019-12-10T18:10:12.443' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (10, N'heyheu', CAST(N'2019-12-10T14:07:45.163' AS DateTime), CAST(N'2019-12-10T14:07:45.163' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (11, N'asdasda', CAST(N'2019-12-10T14:51:50.357' AS DateTime), CAST(N'2019-12-10T14:51:50.357' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (12, N'asdasda', CAST(N'2019-12-10T17:32:14.323' AS DateTime), CAST(N'2019-12-10T17:32:14.323' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (13, N'Merhaaba', CAST(N'2019-12-10T17:36:23.333' AS DateTime), CAST(N'2019-12-10T17:36:23.333' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (14, N'asdasdas', CAST(N'2019-12-10T18:46:34.903' AS DateTime), CAST(N'2019-12-10T18:46:34.903' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (15, N'czxczxvvv', CAST(N'2019-12-10T18:47:00.640' AS DateTime), CAST(N'2019-12-10T18:47:00.640' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (16, N'dsdvsd', CAST(N'2019-12-10T18:47:25.860' AS DateTime), CAST(N'2019-12-10T18:47:25.860' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (17, N'dasdas', CAST(N'2019-12-10T18:52:29.773' AS DateTime), CAST(N'2019-12-10T18:52:29.773' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (18, N'asdasdas', CAST(N'2019-12-10T18:53:23.410' AS DateTime), CAST(N'2019-12-10T18:53:23.410' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (19, N'asdasdas', CAST(N'2019-12-10T18:55:05.167' AS DateTime), CAST(N'2019-12-10T18:55:05.167' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (20, N'asdasd', CAST(N'2019-12-10T18:55:15.177' AS DateTime), CAST(N'2019-12-10T18:55:15.177' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (21, N'nnnnnnnnnnnnnn', CAST(N'2019-12-10T18:55:27.007' AS DateTime), CAST(N'2019-12-10T18:55:27.007' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (22, N'asdasdaszxzczxczxczxczxczxc', CAST(N'2019-12-10T18:57:58.380' AS DateTime), CAST(N'2019-12-10T18:57:58.380' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (23, N'asdasd', CAST(N'2019-12-10T20:13:22.827' AS DateTime), CAST(N'2019-12-10T20:13:22.827' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (24, N'asdasdasd', CAST(N'2019-12-10T20:13:45.293' AS DateTime), CAST(N'2019-12-10T20:13:45.293' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (25, N'asdasd', CAST(N'2019-12-10T20:39:16.723' AS DateTime), CAST(N'2019-12-10T20:39:16.723' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (26, N'thygyhj', CAST(N'2019-12-10T21:59:37.287' AS DateTime), CAST(N'2019-12-10T21:59:37.287' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (27, N'asvvvvvvvvvvvvvvvvvvvvvv', CAST(N'2019-12-12T09:07:14.630' AS DateTime), CAST(N'2019-12-12T09:07:14.630' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (28, N'asvvvvvvvvvvvvvvvvvvvvvv', CAST(N'2019-12-12T09:07:17.550' AS DateTime), CAST(N'2019-12-12T09:07:17.550' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (29, N'asvvvvvvvvvvvvvvvvvvvvvv', CAST(N'2019-12-12T09:07:23.163' AS DateTime), CAST(N'2019-12-12T09:07:23.163' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (30, N'mmmmmmmmmmmmmmmmm', CAST(N'2019-12-12T09:10:51.093' AS DateTime), CAST(N'2019-12-12T09:10:51.093' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (31, N'mmmmmmmmmmmmmmmmm', CAST(N'2019-12-12T09:10:57.037' AS DateTime), CAST(N'2019-12-12T09:10:57.037' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (32, N'asdavbbvbvb', CAST(N'2019-12-12T09:27:28.303' AS DateTime), CAST(N'2019-12-12T09:27:28.303' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (33, N'asdasdacc', CAST(N'2019-12-12T10:00:40.303' AS DateTime), CAST(N'2019-12-12T10:00:40.303' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (34, N'degisklik', CAST(N'2019-12-12T10:41:56.613' AS DateTime), CAST(N'2019-12-12T10:41:56.613' AS DateTime))
INSERT [dbo].[Ders] ([Id], [Ad], [CreatedDate], [ModifiedDate]) VALUES (35, N'degislan', CAST(N'2019-12-12T10:46:09.000' AS DateTime), CAST(N'2019-12-12T10:46:18.120' AS DateTime))
SET IDENTITY_INSERT [dbo].[Ders] OFF
SET IDENTITY_INSERT [dbo].[Ogrenci] ON 

INSERT [dbo].[Ogrenci] ([Id], [No], [Ad], [Soyad], [Gsm], [Eposta], [Durum], [CreatedDate], [ModifiedDate]) VALUES (1, N'string', N'string', N'string', N'string', N'string', 1, CAST(N'2019-10-27T20:28:11.043' AS DateTime), CAST(N'2019-10-28T01:43:52.570' AS DateTime))
INSERT [dbo].[Ogrenci] ([Id], [No], [Ad], [Soyad], [Gsm], [Eposta], [Durum], [CreatedDate], [ModifiedDate]) VALUES (2, N'g151210306', N'Kemal', N'Kaşık', NULL, NULL, 1, CAST(N'2019-10-27T23:43:54.220' AS DateTime), CAST(N'2019-10-27T23:43:54.290' AS DateTime))
INSERT [dbo].[Ogrenci] ([Id], [No], [Ad], [Soyad], [Gsm], [Eposta], [Durum], [CreatedDate], [ModifiedDate]) VALUES (6, N'G91210155', N'asdasd', N'asdasd', NULL, NULL, 0, CAST(N'2019-12-12T12:03:57.913' AS DateTime), CAST(N'2019-12-12T12:03:57.913' AS DateTime))
INSERT [dbo].[Ogrenci] ([Id], [No], [Ad], [Soyad], [Gsm], [Eposta], [Durum], [CreatedDate], [ModifiedDate]) VALUES (7, N'G11210638', N'asdasd', N'asdasdasda', NULL, NULL, 0, CAST(N'2019-12-12T12:04:41.600' AS DateTime), CAST(N'2019-12-12T12:04:41.600' AS DateTime))
INSERT [dbo].[Ogrenci] ([Id], [No], [Ad], [Soyad], [Gsm], [Eposta], [Durum], [CreatedDate], [ModifiedDate]) VALUES (8, N'G91210983', N'asdasda', N'asdasdasa', NULL, NULL, 0, CAST(N'2019-12-12T12:10:06.910' AS DateTime), CAST(N'2019-12-12T12:10:06.910' AS DateTime))
INSERT [dbo].[Ogrenci] ([Id], [No], [Ad], [Soyad], [Gsm], [Eposta], [Durum], [CreatedDate], [ModifiedDate]) VALUES (9, N'G191210975', N'adamgibikayit', N'adam', NULL, NULL, 1, CAST(N'2019-12-12T12:16:35.873' AS DateTime), CAST(N'2019-12-12T12:16:35.873' AS DateTime))
INSERT [dbo].[Ogrenci] ([Id], [No], [Ad], [Soyad], [Gsm], [Eposta], [Durum], [CreatedDate], [ModifiedDate]) VALUES (10, N'G191210450', N'kazım', N'karabekir', NULL, NULL, 0, CAST(N'2019-12-12T13:08:29.927' AS DateTime), CAST(N'2019-12-12T13:08:29.927' AS DateTime))
INSERT [dbo].[Ogrenci] ([Id], [No], [Ad], [Soyad], [Gsm], [Eposta], [Durum], [CreatedDate], [ModifiedDate]) VALUES (11, N'G191210317', N'asdasd', N'asdasdas', N'0552174845', N'nasoıasfıhnafohıs@gmail.com', 1, CAST(N'2019-12-12T13:20:22.387' AS DateTime), CAST(N'2019-12-12T13:20:22.387' AS DateTime))
SET IDENTITY_INSERT [dbo].[Ogrenci] OFF
ALTER TABLE [dbo].[DersSinif]  WITH CHECK ADD  CONSTRAINT [FK_DersSinif_Ders] FOREIGN KEY([DersId])
REFERENCES [dbo].[Ders] ([Id])
GO
ALTER TABLE [dbo].[DersSinif] CHECK CONSTRAINT [FK_DersSinif_Ders]
GO
ALTER TABLE [dbo].[DersSinif]  WITH CHECK ADD  CONSTRAINT [FK_DersSinif_Sinif] FOREIGN KEY([SinifId])
REFERENCES [dbo].[Sinif] ([Id])
GO
ALTER TABLE [dbo].[DersSinif] CHECK CONSTRAINT [FK_DersSinif_Sinif]
GO
ALTER TABLE [dbo].[OgrenciDers]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDers_Ders1] FOREIGN KEY([DersId])
REFERENCES [dbo].[Ders] ([Id])
GO
ALTER TABLE [dbo].[OgrenciDers] CHECK CONSTRAINT [FK_OgrenciDers_Ders1]
GO
ALTER TABLE [dbo].[OgrenciDers]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDers_Ogrenci] FOREIGN KEY([OgrenciId])
REFERENCES [dbo].[Ogrenci] ([Id])
GO
ALTER TABLE [dbo].[OgrenciDers] CHECK CONSTRAINT [FK_OgrenciDers_Ogrenci]
GO
USE [master]
GO
ALTER DATABASE [EgitimSistemiDemo] SET  READ_WRITE 
GO
