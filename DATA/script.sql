USE [master]
GO
/****** Object:  Database [restaurant]    Script Date: 6/8/2017 12:45:09 PM ******/
CREATE DATABASE [restaurant]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'restaurant', FILENAME = N'C:\Users\epicodus\restaurant.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'restaurant_log', FILENAME = N'C:\Users\epicodus\restaurant_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [restaurant] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [restaurant].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [restaurant] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [restaurant] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [restaurant] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [restaurant] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [restaurant] SET ARITHABORT OFF 
GO
ALTER DATABASE [restaurant] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [restaurant] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [restaurant] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [restaurant] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [restaurant] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [restaurant] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [restaurant] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [restaurant] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [restaurant] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [restaurant] SET  DISABLE_BROKER 
GO
ALTER DATABASE [restaurant] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [restaurant] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [restaurant] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [restaurant] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [restaurant] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [restaurant] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [restaurant] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [restaurant] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [restaurant] SET  MULTI_USER 
GO
ALTER DATABASE [restaurant] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [restaurant] SET DB_CHAINING OFF 
GO
ALTER DATABASE [restaurant] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [restaurant] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [restaurant] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [restaurant] SET QUERY_STORE = OFF
GO
USE [restaurant]
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
USE [restaurant]
GO
/****** Object:  Table [dbo].[cuisine]    Script Date: 6/8/2017 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuisine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[restaurant]    Script Date: 6/8/2017 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[restaurant](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[cuisine_id] [int] NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [restaurant] SET  READ_WRITE 
GO
