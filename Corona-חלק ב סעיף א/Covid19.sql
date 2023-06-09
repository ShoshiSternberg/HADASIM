USE [master]
GO
/****** Object:  Database [Covid19]    Script Date: 11/05/2023 21:00:05 ******/
CREATE DATABASE [Covid19]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Covid19', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Covid19.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Covid19_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Covid19_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Covid19].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Covid19] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Covid19] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Covid19] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Covid19] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Covid19] SET ARITHABORT OFF 
GO
ALTER DATABASE [Covid19] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Covid19] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Covid19] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Covid19] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Covid19] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Covid19] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Covid19] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Covid19] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Covid19] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Covid19] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Covid19] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Covid19] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Covid19] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Covid19] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Covid19] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Covid19] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Covid19] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Covid19] SET RECOVERY FULL 
GO
ALTER DATABASE [Covid19] SET  MULTI_USER 
GO
ALTER DATABASE [Covid19] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Covid19] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Covid19] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Covid19] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Covid19] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Covid19', N'ON'
GO
ALTER DATABASE [Covid19] SET QUERY_STORE = OFF
GO
USE [Covid19]
GO
/****** Object:  Table [dbo].[entities]    Script Date: 11/05/2023 21:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[entities](
	[entity_id] [int] NOT NULL,
	[first_name] [nchar](10) NULL,
	[last_name] [nchar](10) NULL,
	[birth_date] [date] NULL,
	[phone] [nchar](10) NULL,
	[cell_phone] [nchar](10) NULL,
	[employee] [bit] NULL,
	[city] [nchar](10) NULL,
	[street] [nchar](10) NULL,
	[street_num] [int] NULL,
 CONSTRAINT [PK_entities] PRIMARY KEY CLUSTERED 
(
	[entity_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[manufacturer]    Script Date: 11/05/2023 21:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[manufacturer](
	[manufacturer_id] [int] IDENTITY(1,1) NOT NULL,
	[manufacturer_name] [nchar](10) NULL,
	[phone_order] [nchar](10) NULL,
 CONSTRAINT [PK_manufacturer] PRIMARY KEY CLUSTERED 
(
	[manufacturer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 11/05/2023 21:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patients](
	[patient_id] [int] IDENTITY(1,1) NOT NULL,
	[entity_id] [int] NOT NULL,
	[positve_date] [date] NULL,
	[recovery_date] [date] NULL,
 CONSTRAINT [PK_patients] PRIMARY KEY CLUSTERED 
(
	[patient_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vaccinated]    Script Date: 11/05/2023 21:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vaccinated](
	[datails_id] [int] IDENTITY(1,1) NOT NULL,
	[entity_id] [int] NOT NULL,
	[vaccine_id] [int] NOT NULL,
	[receiving_date] [date] NOT NULL,
 CONSTRAINT [PK_vaccinated] PRIMARY KEY CLUSTERED 
(
	[datails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vaccine]    Script Date: 11/05/2023 21:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vaccine](
	[vaccine_id] [int] NOT NULL,
	[name_vaccine] [nchar](10) NULL,
	[manufacturer_id] [int] NOT NULL,
	[count_vaccine] [int] NOT NULL,
	[manufacturing_date] [date] NULL,
	[expiry_date] [date] NULL,
 CONSTRAINT [PK_vaccine] PRIMARY KEY CLUSTERED 
(
	[vaccine_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[entities] ([entity_id], [first_name], [last_name], [birth_date], [phone], [cell_phone], [employee], [city], [street], [street_num]) VALUES (61207619, N'אילה      ', N'דמארי     ', CAST(N'2003-08-29' AS Date), N'0533119881', N'039090384 ', 0, N'אלעד      ', N'אבן גבירול', 8)
INSERT [dbo].[entities] ([entity_id], [first_name], [last_name], [birth_date], [phone], [cell_phone], [employee], [city], [street], [street_num]) VALUES (215913559, N'fr        ', N'          ', CAST(N'0001-01-01' AS Date), N'          ', N'          ', 0, N'          ', N'          ', 0)
INSERT [dbo].[entities] ([entity_id], [first_name], [last_name], [birth_date], [phone], [cell_phone], [employee], [city], [street], [street_num]) VALUES (325562221, N'          ', N'jufy      ', CAST(N'0001-01-01' AS Date), N'          ', N'          ', 0, N'          ', N'          ', 0)
GO
SET IDENTITY_INSERT [dbo].[manufacturer] ON 

INSERT [dbo].[manufacturer] ([manufacturer_id], [manufacturer_name], [phone_order]) VALUES (1, N'פייזר     ', N'0888888888')
INSERT [dbo].[manufacturer] ([manufacturer_id], [manufacturer_name], [phone_order]) VALUES (2, N'מודרנה    ', N'0888888887')
INSERT [dbo].[manufacturer] ([manufacturer_id], [manufacturer_name], [phone_order]) VALUES (3, N'בגיר      ', N'0888888889')
INSERT [dbo].[manufacturer] ([manufacturer_id], [manufacturer_name], [phone_order]) VALUES (4, N'חיסנן     ', N'0888888888')
SET IDENTITY_INSERT [dbo].[manufacturer] OFF
GO
SET IDENTITY_INSERT [dbo].[patients] ON 

INSERT [dbo].[patients] ([patient_id], [entity_id], [positve_date], [recovery_date]) VALUES (26, 325562221, CAST(N'2023-04-09' AS Date), CAST(N'2023-09-09' AS Date))
INSERT [dbo].[patients] ([patient_id], [entity_id], [positve_date], [recovery_date]) VALUES (29, 325562221, CAST(N'2023-04-09' AS Date), CAST(N'2025-09-09' AS Date))
INSERT [dbo].[patients] ([patient_id], [entity_id], [positve_date], [recovery_date]) VALUES (33, 325562221, CAST(N'2023-09-09' AS Date), CAST(N'2022-09-10' AS Date))
SET IDENTITY_INSERT [dbo].[patients] OFF
GO
SET IDENTITY_INSERT [dbo].[vaccinated] ON 

INSERT [dbo].[vaccinated] ([datails_id], [entity_id], [vaccine_id], [receiving_date]) VALUES (1, 325562221, 0, CAST(N'2022-09-09' AS Date))
INSERT [dbo].[vaccinated] ([datails_id], [entity_id], [vaccine_id], [receiving_date]) VALUES (2, 325562221, 0, CAST(N'2099-09-09' AS Date))
INSERT [dbo].[vaccinated] ([datails_id], [entity_id], [vaccine_id], [receiving_date]) VALUES (3, 325562221, 0, CAST(N'8888-09-09' AS Date))
INSERT [dbo].[vaccinated] ([datails_id], [entity_id], [vaccine_id], [receiving_date]) VALUES (4, 325562221, 0, CAST(N'0001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[vaccinated] OFF
GO
INSERT [dbo].[vaccine] ([vaccine_id], [name_vaccine], [manufacturer_id], [count_vaccine], [manufacturing_date], [expiry_date]) VALUES (0, N'פייזר     ', 1, 5, CAST(N'2022-09-09' AS Date), CAST(N'2023-09-09' AS Date))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD  CONSTRAINT [FK_patients_entities] FOREIGN KEY([entity_id])
REFERENCES [dbo].[entities] ([entity_id])
GO
ALTER TABLE [dbo].[patients] CHECK CONSTRAINT [FK_patients_entities]
GO
ALTER TABLE [dbo].[vaccinated]  WITH CHECK ADD  CONSTRAINT [FK_vaccinated_entities] FOREIGN KEY([entity_id])
REFERENCES [dbo].[entities] ([entity_id])
GO
ALTER TABLE [dbo].[vaccinated] CHECK CONSTRAINT [FK_vaccinated_entities]
GO
ALTER TABLE [dbo].[vaccinated]  WITH CHECK ADD  CONSTRAINT [FK_vaccinated_vaccine] FOREIGN KEY([vaccine_id])
REFERENCES [dbo].[vaccine] ([vaccine_id])
GO
ALTER TABLE [dbo].[vaccinated] CHECK CONSTRAINT [FK_vaccinated_vaccine]
GO
ALTER TABLE [dbo].[vaccine]  WITH CHECK ADD  CONSTRAINT [FK_vaccine_manufacturer] FOREIGN KEY([manufacturer_id])
REFERENCES [dbo].[manufacturer] ([manufacturer_id])
GO
ALTER TABLE [dbo].[vaccine] CHECK CONSTRAINT [FK_vaccine_manufacturer]
GO
USE [master]
GO
ALTER DATABASE [Covid19] SET  READ_WRITE 
GO
