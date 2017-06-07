USE [master]
GO
/****** Object:  Database [portland_test]    Script Date: 6/7/2017 4:09:47 PM ******/
CREATE DATABASE [portland_test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'portland', FILENAME = N'C:\Users\epicodus\portland_test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'portland_log', FILENAME = N'C:\Users\epicodus\portland_test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [portland_test] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [portland_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [portland_test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [portland_test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [portland_test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [portland_test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [portland_test] SET ARITHABORT OFF 
GO
ALTER DATABASE [portland_test] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [portland_test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [portland_test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [portland_test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [portland_test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [portland_test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [portland_test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [portland_test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [portland_test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [portland_test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [portland_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [portland_test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [portland_test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [portland_test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [portland_test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [portland_test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [portland_test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [portland_test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [portland_test] SET  MULTI_USER 
GO
ALTER DATABASE [portland_test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [portland_test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [portland_test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [portland_test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [portland_test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [portland_test] SET QUERY_STORE = OFF
GO
USE [portland_test]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [portland_test]
GO
/****** Object:  Table [dbo].[cuisine]    Script Date: 6/7/2017 4:09:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuisine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[restaurant]    Script Date: 6/7/2017 4:09:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[restaurant](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[rating] [int] NULL,
	[availability] [varchar](50) NULL,
	[cuisine_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[review]    Script Date: 6/7/2017 4:09:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[review](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[opinion] [text] NULL,
	[restaurant_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [portland_test] SET  READ_WRITE 
GO
