USE [master]
GO
/****** Object:  Database [portland]    Script Date: 6/7/2017 4:53:04 PM ******/
CREATE DATABASE [portland]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'portland', FILENAME = N'C:\Users\epicodus\portland.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'portland_log', FILENAME = N'C:\Users\epicodus\portland_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [portland] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [portland].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [portland] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [portland] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [portland] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [portland] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [portland] SET ARITHABORT OFF 
GO
ALTER DATABASE [portland] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [portland] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [portland] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [portland] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [portland] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [portland] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [portland] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [portland] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [portland] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [portland] SET  ENABLE_BROKER 
GO
ALTER DATABASE [portland] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [portland] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [portland] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [portland] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [portland] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [portland] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [portland] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [portland] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [portland] SET  MULTI_USER 
GO
ALTER DATABASE [portland] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [portland] SET DB_CHAINING OFF 
GO
ALTER DATABASE [portland] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [portland] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [portland] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [portland] SET QUERY_STORE = OFF
GO
USE [portland]
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
USE [portland]
GO
/****** Object:  Table [dbo].[cuisine]    Script Date: 6/7/2017 4:53:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuisine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[restaurant]    Script Date: 6/7/2017 4:53:04 PM ******/
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
/****** Object:  Table [dbo].[review]    Script Date: 6/7/2017 4:53:04 PM ******/
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
SET IDENTITY_INSERT [dbo].[cuisine] ON 

INSERT [dbo].[cuisine] ([id], [type]) VALUES (1, N'Mexican')
INSERT [dbo].[cuisine] ([id], [type]) VALUES (2, N'Japanese')
INSERT [dbo].[cuisine] ([id], [type]) VALUES (3, N'Chinese')
INSERT [dbo].[cuisine] ([id], [type]) VALUES (4, N'American')
SET IDENTITY_INSERT [dbo].[cuisine] OFF
SET IDENTITY_INSERT [dbo].[restaurant] ON 

INSERT [dbo].[restaurant] ([id], [name], [rating], [availability], [cuisine_id]) VALUES (1, N'Santeria', 5, N'Open M-F 10am - 11pm, Sat-Sun 11am - 4am', 1)
INSERT [dbo].[restaurant] ([id], [name], [rating], [availability], [cuisine_id]) VALUES (2, N'Marakun', 5, N'Open 11am-3pm, 5pm-10pm', 2)
INSERT [dbo].[restaurant] ([id], [name], [rating], [availability], [cuisine_id]) VALUES (3, N'August Moon', 4, N'Open 11am-11pm', 3)
INSERT [dbo].[restaurant] ([id], [name], [rating], [availability], [cuisine_id]) VALUES (4, N'Burgerville', 3, N'Open 8am-11pm', 4)
INSERT [dbo].[restaurant] ([id], [name], [rating], [availability], [cuisine_id]) VALUES (5, N'Javier''s', 2, N'Open 11am-5am', 1)
SET IDENTITY_INSERT [dbo].[restaurant] OFF
SET IDENTITY_INSERT [dbo].[review] ON 

INSERT [dbo].[review] ([id], [opinion], [restaurant_id]) VALUES (1, N'Saw a cockroach, I was drunk though it could''ve been a hairband.', 5)
INSERT [dbo].[review] ([id], [opinion], [restaurant_id]) VALUES (2, N'Excellent shashimi quaility.', 2)
INSERT [dbo].[review] ([id], [opinion], [restaurant_id]) VALUES (3, N'Love this place! ', 1)
INSERT [dbo].[review] ([id], [opinion], [restaurant_id]) VALUES (4, N'Love this place! ', 1)
INSERT [dbo].[review] ([id], [opinion], [restaurant_id]) VALUES (5, N'Love this place! ', 1)
INSERT [dbo].[review] ([id], [opinion], [restaurant_id]) VALUES (6, N'Love this place! ', 1)
INSERT [dbo].[review] ([id], [opinion], [restaurant_id]) VALUES (7, N'Love this place! ', 1)
INSERT [dbo].[review] ([id], [opinion], [restaurant_id]) VALUES (8, N'This is my favorite restaurant!', 5)
INSERT [dbo].[review] ([id], [opinion], [restaurant_id]) VALUES (9, N'This is my favorite restaurant!', 5)
SET IDENTITY_INSERT [dbo].[review] OFF
USE [master]
GO
ALTER DATABASE [portland] SET  READ_WRITE 
GO
