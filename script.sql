USE [master]
GO
/****** Object:  Database [DB_Kitchen_180]    Script Date: 23/11/2018 15:16:38 ******/
CREATE DATABASE [DB_Kitchen_180]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Kitchen_180', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DB_Kitchen_180.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Kitchen_180_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DB_Kitchen_180_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DB_Kitchen_180] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Kitchen_180].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Kitchen_180] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_Kitchen_180] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Kitchen_180] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Kitchen_180] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Kitchen_180] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Kitchen_180] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DB_Kitchen_180] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Kitchen_180] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Kitchen_180] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Kitchen_180] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Kitchen_180] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Kitchen_180] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Kitchen_180] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Kitchen_180] SET QUERY_STORE = OFF
GO
USE [DB_Kitchen_180]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 23/11/2018 15:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 23/11/2018 15:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[initial] [varchar](10) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 23/11/2018 15:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] NOT NULL,
	[reservid] [int] NOT NULL,
	[productid] [int] NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
	[status] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 23/11/2018 15:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categoryid] [int] NOT NULL,
	[initial] [varchar](10) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](100) NOT NULL,
	[price] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 23/11/2018 15:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[id] [int] NOT NULL,
	[tableid] [int] NOT NULL,
	[reference] [varchar](20) NOT NULL,
	[guest] [varchar](50) NOT NULL,
	[Paid] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Reservations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 23/11/2018 15:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[initial] [varchar](10) NOT NULL,
	[Seat] [int] NOT NULL,
	[Desc] [varchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Tables] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_productid]    Script Date: 23/11/2018 15:16:38 ******/
CREATE NONCLUSTERED INDEX [IX_productid] ON [dbo].[Orders]
(
	[productid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_reservid]    Script Date: 23/11/2018 15:16:38 ******/
CREATE NONCLUSTERED INDEX [IX_reservid] ON [dbo].[Orders]
(
	[reservid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_categoryid]    Script Date: 23/11/2018 15:16:38 ******/
CREATE NONCLUSTERED INDEX [IX_categoryid] ON [dbo].[Products]
(
	[categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tableid]    Script Date: 23/11/2018 15:16:38 ******/
CREATE NONCLUSTERED INDEX [IX_tableid] ON [dbo].[Reservations]
(
	[tableid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Products_productid] FOREIGN KEY([productid])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Products_productid]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Reservations_reservid] FOREIGN KEY([reservid])
REFERENCES [dbo].[Reservations] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Reservations_reservid]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Category_categoryid] FOREIGN KEY([categoryid])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Category_categoryid]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Reservations_dbo.Tables_tableid] FOREIGN KEY([tableid])
REFERENCES [dbo].[Tables] ([id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_dbo.Reservations_dbo.Tables_tableid]
GO
USE [master]
GO
ALTER DATABASE [DB_Kitchen_180] SET  READ_WRITE 
GO
