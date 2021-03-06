USE [master]
GO
/****** Object:  Database [CrudMvcFetch]    Script Date: 4/10/2021 12:11:38 p. m. ******/
CREATE DATABASE [CrudMvcFetch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CrudMvcFetch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CrudMvcFetch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CrudMvcFetch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CrudMvcFetch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CrudMvcFetch] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CrudMvcFetch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CrudMvcFetch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET ARITHABORT OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CrudMvcFetch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CrudMvcFetch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CrudMvcFetch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CrudMvcFetch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET RECOVERY FULL 
GO
ALTER DATABASE [CrudMvcFetch] SET  MULTI_USER 
GO
ALTER DATABASE [CrudMvcFetch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CrudMvcFetch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CrudMvcFetch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CrudMvcFetch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CrudMvcFetch] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CrudMvcFetch] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CrudMvcFetch', N'ON'
GO
ALTER DATABASE [CrudMvcFetch] SET QUERY_STORE = OFF
GO
USE [CrudMvcFetch]
GO
/****** Object:  Table [dbo].[people]    Script Date: 4/10/2021 12:11:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[people](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NULL,
	[age] [int] NULL,
	[dateBird] [date] NULL,
 CONSTRAINT [PK_people_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/10/2021 12:11:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IdPeople] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[people] ON 

INSERT [dbo].[people] ([id], [name], [lastName], [age], [dateBird]) VALUES (1, N'omarlin gr', N'Garces Rodriguez', 21, CAST(N'2021-10-08' AS Date))
INSERT [dbo].[people] ([id], [name], [lastName], [age], [dateBird]) VALUES (2, N'lepida', N'Rodriguez Aren', 49, CAST(N'1975-02-15' AS Date))
INSERT [dbo].[people] ([id], [name], [lastName], [age], [dateBird]) VALUES (3, N'rosa', N'Torres', 24, CAST(N'1997-10-10' AS Date))
INSERT [dbo].[people] ([id], [name], [lastName], [age], [dateBird]) VALUES (4, N'magali', N'Peralta', 56, CAST(N'1965-03-06' AS Date))
INSERT [dbo].[people] ([id], [name], [lastName], [age], [dateBird]) VALUES (5, N'bienvenido', N'garces rodriguez', 57, CAST(N'1965-03-06' AS Date))
SET IDENTITY_INSERT [dbo].[people] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password], [IdPeople]) VALUES (1, N'omarlindev', N'123', 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [IdPeople]) VALUES (2, N'lepidadev', N'123', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_people] FOREIGN KEY([IdPeople])
REFERENCES [dbo].[people] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_people]
GO
USE [master]
GO
ALTER DATABASE [CrudMvcFetch] SET  READ_WRITE 
GO
