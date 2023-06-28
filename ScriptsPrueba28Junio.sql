USE [master]
GO
/****** Object:  Database [GrupoTranspaisDaniel]    Script Date: 6/28/2023 12:47:36 AM ******/
CREATE DATABASE [GrupoTranspaisDaniel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GrupoTranspaisDaniel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GrupoTranspaisDaniel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GrupoTranspaisDaniel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GrupoTranspaisDaniel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GrupoTranspaisDaniel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET ARITHABORT OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET RECOVERY FULL 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET  MULTI_USER 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GrupoTranspaisDaniel', N'ON'
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET QUERY_STORE = OFF
GO
USE [GrupoTranspaisDaniel]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 6/28/2023 12:47:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](200) NULL,
	[apellido] [nvarchar](200) NULL,
	[edad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[persona] ON 
GO
INSERT [dbo].[persona] ([id], [nombre], [apellido], [edad]) VALUES (1, N'pepe', N'pedro', 12)
GO
INSERT [dbo].[persona] ([id], [nombre], [apellido], [edad]) VALUES (2, N'pepe', N'pedro', 12)
GO
INSERT [dbo].[persona] ([id], [nombre], [apellido], [edad]) VALUES (3, N'pepe', N'pedro', 12)
GO
INSERT [dbo].[persona] ([id], [nombre], [apellido], [edad]) VALUES (4, N'pepe', N'pedro', 12)
GO
INSERT [dbo].[persona] ([id], [nombre], [apellido], [edad]) VALUES (5, N'alejandro', N'perez', 13)
GO
INSERT [dbo].[persona] ([id], [nombre], [apellido], [edad]) VALUES (6, N'alejandro', N'perez', 13)
GO
INSERT [dbo].[persona] ([id], [nombre], [apellido], [edad]) VALUES (7, N'jefe', N'', 0)
GO
SET IDENTITY_INSERT [dbo].[persona] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_Insertar]    Script Date: 6/28/2023 12:47:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Insertar] 
@nombre nvarchar(200),
@apellido nvarchar(200),
@edad int
as 
insert into persona(nombre, apellido, edad)
values (@nombre, @apellido,@edad);
GO
USE [master]
GO
ALTER DATABASE [GrupoTranspaisDaniel] SET  READ_WRITE 
GO
