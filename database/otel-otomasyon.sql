USE [master]
GO
/****** Object:  Database [Otel]    Script Date: 18.07.2022 03:33:01 ******/
CREATE DATABASE [Otel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Otel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Otel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Otel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Otel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Otel] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Otel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Otel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Otel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Otel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Otel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Otel] SET ARITHABORT OFF 
GO
ALTER DATABASE [Otel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Otel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Otel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Otel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Otel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Otel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Otel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Otel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Otel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Otel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Otel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Otel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Otel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Otel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Otel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Otel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Otel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Otel] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Otel] SET  MULTI_USER 
GO
ALTER DATABASE [Otel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Otel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Otel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Otel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Otel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Otel] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Otel] SET QUERY_STORE = OFF
GO
USE [Otel]
GO
/****** Object:  User [Alperen]    Script Date: 18.07.2022 03:33:01 ******/
CREATE USER [Alperen] FOR LOGIN [Alperen] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[il]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[il](
	[il_id] [int] IDENTITY(1,1) NOT NULL,
	[iller] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__il__ACA9B93F40449C4F] PRIMARY KEY CLUSTERED 
(
	[il_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ilce]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ilce](
	[ilce_id] [int] IDENTITY(1,1) NOT NULL,
	[ilceler] [nvarchar](20) NOT NULL,
	[il_no] [int] NOT NULL,
 CONSTRAINT [PK__ilce__441D84882A81306D] PRIMARY KEY CLUSTERED 
(
	[ilce_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[menu_id] [int] IDENTITY(1,1) NOT NULL,
	[menu_adı] [nvarchar](50) NOT NULL,
	[menu_fiyat] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_icerik]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_icerik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[menu_icerik] [nvarchar](50) NOT NULL,
	[menu_id] [int] NOT NULL,
 CONSTRAINT [PK_Menu_icerik] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[Müsteri_id] [int] IDENTITY(1,1) NOT NULL,
	[Musteri_adi] [varchar](50) NOT NULL,
	[Musteri_soyad] [varchar](50) NOT NULL,
	[Musteri_Tc] [varchar](50) NOT NULL,
	[Musteri_telefon] [varchar](50) NOT NULL,
	[Musteri_uyruk] [varchar](50) NOT NULL,
	[Musteri_cinsiyet] [varchar](50) NOT NULL,
	[Musteri_adres] [varchar](50) NOT NULL,
	[Musteri_kan] [varchar](50) NOT NULL,
	[Musteri_eposta] [varchar](50) NOT NULL,
	[Il] [int] NULL,
	[Ilce] [int] NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[Müsteri_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri_hesap]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri_hesap](
	[islem_no] [int] IDENTITY(1,1) NOT NULL,
	[musteri_no] [int] NULL,
	[oda_no] [int] NULL,
	[giris_tarihi] [date] NOT NULL,
	[cikis_tarihi] [date] NULL,
	[kisi_sayisi] [int] NOT NULL,
 CONSTRAINT [PK_Musteri_hesap] PRIMARY KEY CLUSTERED 
(
	[islem_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda](
	[Oda_id] [int] IDENTITY(1,1) NOT NULL,
	[OdaNo] [nchar](10) NOT NULL,
	[Oda_kat] [nchar](10) NOT NULL,
	[Oda_fiyat] [nchar](10) NOT NULL,
	[Oda_Tür_İd] [int] NOT NULL,
 CONSTRAINT [PK_il] PRIMARY KEY CLUSTERED 
(
	[Oda_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda_tür]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda_tür](
	[tür_id] [int] IDENTITY(1,1) NOT NULL,
	[Tür_adı] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Oda_tür] PRIMARY KEY CLUSTERED 
(
	[tür_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[Personel_id] [int] IDENTITY(1,1) NOT NULL,
	[Personel_ad] [nvarchar](50) NOT NULL,
	[Personel_soyad] [nvarchar](50) NOT NULL,
	[Personel_cinsiyet] [nchar](10) NOT NULL,
	[Personel_maas] [nchar](10) NOT NULL,
	[Personel_Telefon] [nvarchar](11) NOT NULL,
	[Personel_Dtarih] [date] NOT NULL,
	[Personel_işegiriş_tarihi] [date] NOT NULL,
	[Personel_İştençıkış_Tarihi] [date] NOT NULL,
	[Personel_email] [nvarchar](50) NOT NULL,
	[Personel_KanGrubu] [nchar](10) NOT NULL,
	[personel_görev_id] [int] NOT NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[Personel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel_Görev]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel_Görev](
	[Personel_Görev_İd] [int] IDENTITY(1,1) NOT NULL,
	[Görev_Adı] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Personel_Görev] PRIMARY KEY CLUSTERED 
(
	[Personel_Görev_İd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparis]    Script Date: 18.07.2022 03:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparis](
	[hesap_no] [int] NOT NULL,
	[menu_id] [int] NOT NULL,
	[hesap] [nvarchar](50) NOT NULL,
	[siparis_tarihi] [datetime] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Siparis] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ilce]  WITH CHECK ADD  CONSTRAINT [FK_ilce_il] FOREIGN KEY([il_no])
REFERENCES [dbo].[il] ([il_id])
GO
ALTER TABLE [dbo].[ilce] CHECK CONSTRAINT [FK_ilce_il]
GO
ALTER TABLE [dbo].[Menu_icerik]  WITH CHECK ADD  CONSTRAINT [FK_Menu_icerik_Menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[Menu] ([menu_id])
GO
ALTER TABLE [dbo].[Menu_icerik] CHECK CONSTRAINT [FK_Menu_icerik_Menu]
GO
ALTER TABLE [dbo].[Musteri]  WITH CHECK ADD  CONSTRAINT [FK_Musteri_il] FOREIGN KEY([Il])
REFERENCES [dbo].[il] ([il_id])
GO
ALTER TABLE [dbo].[Musteri] CHECK CONSTRAINT [FK_Musteri_il]
GO
ALTER TABLE [dbo].[Musteri]  WITH CHECK ADD  CONSTRAINT [FK_Musteri_ilce] FOREIGN KEY([Ilce])
REFERENCES [dbo].[ilce] ([ilce_id])
GO
ALTER TABLE [dbo].[Musteri] CHECK CONSTRAINT [FK_Musteri_ilce]
GO
ALTER TABLE [dbo].[Musteri_hesap]  WITH CHECK ADD  CONSTRAINT [FK_Musteri_hesap_Musteri] FOREIGN KEY([musteri_no])
REFERENCES [dbo].[Musteri] ([Müsteri_id])
GO
ALTER TABLE [dbo].[Musteri_hesap] CHECK CONSTRAINT [FK_Musteri_hesap_Musteri]
GO
ALTER TABLE [dbo].[Musteri_hesap]  WITH CHECK ADD  CONSTRAINT [FK_Musteri_hesap_Oda] FOREIGN KEY([oda_no])
REFERENCES [dbo].[Oda] ([Oda_id])
GO
ALTER TABLE [dbo].[Musteri_hesap] CHECK CONSTRAINT [FK_Musteri_hesap_Oda]
GO
ALTER TABLE [dbo].[Oda]  WITH CHECK ADD  CONSTRAINT [FK_Oda_Oda_tür] FOREIGN KEY([Oda_Tür_İd])
REFERENCES [dbo].[Oda_tür] ([tür_id])
GO
ALTER TABLE [dbo].[Oda] CHECK CONSTRAINT [FK_Oda_Oda_tür]
GO
ALTER TABLE [dbo].[Personel]  WITH CHECK ADD  CONSTRAINT [FK_Personel_Personel_Görev] FOREIGN KEY([personel_görev_id])
REFERENCES [dbo].[Personel_Görev] ([Personel_Görev_İd])
GO
ALTER TABLE [dbo].[Personel] CHECK CONSTRAINT [FK_Personel_Personel_Görev]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[Menu] ([menu_id])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Menu]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Musteri_hesap] FOREIGN KEY([hesap_no])
REFERENCES [dbo].[Musteri_hesap] ([islem_no])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Musteri_hesap]
GO
USE [master]
GO
ALTER DATABASE [Otel] SET  READ_WRITE 
GO
