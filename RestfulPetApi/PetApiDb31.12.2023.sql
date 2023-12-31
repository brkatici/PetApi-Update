USE [master]
GO
/****** Object:  Database [PetApiDb]    Script Date: 31.12.2023 06:57:54 ******/
CREATE DATABASE [PetApiDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PetApiDb', FILENAME = N'C:\Users\Burak\OneDrive\Masaüstü\DBs\PetApiDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PetApiDb_log', FILENAME = N'C:\Users\Burak\OneDrive\Masaüstü\DBs\PetApiDb_log.ldf' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PetApiDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PetApiDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PetApiDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PetApiDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PetApiDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PetApiDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PetApiDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [PetApiDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PetApiDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PetApiDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PetApiDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PetApiDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PetApiDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PetApiDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PetApiDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PetApiDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PetApiDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PetApiDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PetApiDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PetApiDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PetApiDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PetApiDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PetApiDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PetApiDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PetApiDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PetApiDb] SET  MULTI_USER 
GO
ALTER DATABASE [PetApiDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PetApiDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PetApiDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PetApiDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PetApiDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PetApiDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PetApiDb', N'ON'
GO
ALTER DATABASE [PetApiDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [PetApiDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PetApiDb]
GO
/****** Object:  User [Burakk]    Script Date: 31.12.2023 06:57:54 ******/
CREATE USER [Burakk] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 31.12.2023 06:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 31.12.2023 06:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[ActivityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PetId] [int] NOT NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 31.12.2023 06:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[FoodId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[PetId] [int] NOT NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[FoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HealthStatuses]    Script Date: 31.12.2023 06:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthStatuses](
	[HealthStatusId] [int] IDENTITY(1,1) NOT NULL,
	[PetId] [int] NOT NULL,
	[Weight] [float] NOT NULL,
	[LastCheckupDate] [datetime2](7) NOT NULL,
	[VaccinationRecords] [nvarchar](max) NOT NULL,
	[Diseases] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_HealthStatuses] PRIMARY KEY CLUSTERED 
(
	[HealthStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pets]    Script Date: 31.12.2023 06:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pets](
	[PetId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Species] [nvarchar](max) NULL,
	[Age] [int] NULL,
	[Gender] [nvarchar](max) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Pets] PRIMARY KEY CLUSTERED 
(
	[PetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialInteractions]    Script Date: 31.12.2023 06:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialInteractions](
	[SocialInteractionId] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[Pet1] [int] NOT NULL,
	[Pet2] [int] NOT NULL,
 CONSTRAINT [PK_SocialInteractions] PRIMARY KEY CLUSTERED 
(
	[SocialInteractionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainings]    Script Date: 31.12.2023 06:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainings](
	[TrainingId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PetId] [int] NOT NULL,
 CONSTRAINT [PK_Trainings] PRIMARY KEY CLUSTERED 
(
	[TrainingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 31.12.2023 06:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231215201557_InitialCreate', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231215202354_Activity', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231216001714_NewActivityColumnAdded', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231216003831_NewFoodColumnAdded', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231223034308_NewClassesAdded', N'7.0.0')
GO
SET IDENTITY_INSERT [dbo].[Activities] ON 

INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (1, N'Koşma', 1)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (2, N'Uyuma', 1)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (3, N'Oyun', 1)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (4, N'Yemek', 3)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (5, N'Su içme', 2)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (6, N'Isırma', 2)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (7, N'Top Oynama', 2)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (8, N'Tutma', 4)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (9, N'Hastalanma', 3)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (10, N'Kaçma', 2)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (11, N'Oturma', 3)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (12, N'Korkma', 2)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (13, N'Zoomiess', 4)
INSERT [dbo].[Activities] ([ActivityId], [Name], [PetId]) VALUES (14, N'Çok yoruldu', 4)
SET IDENTITY_INSERT [dbo].[Activities] OFF
GO
SET IDENTITY_INSERT [dbo].[Foods] ON 

INSERT [dbo].[Foods] ([FoodId], [Name], [Description], [PetId]) VALUES (1, N'Kibble', N'Dry dog food', 3)
INSERT [dbo].[Foods] ([FoodId], [Name], [Description], [PetId]) VALUES (2, N'Tuna Delight', N'Canned tuna for cats', 1)
INSERT [dbo].[Foods] ([FoodId], [Name], [Description], [PetId]) VALUES (3, N'Chewy Treats', N'Delicious chewy treats', 2)
INSERT [dbo].[Foods] ([FoodId], [Name], [Description], [PetId]) VALUES (4, N'Chicken Bits', N'Chicken-flavored bits', 3)
INSERT [dbo].[Foods] ([FoodId], [Name], [Description], [PetId]) VALUES (5, N'Fish Fillet', N'Fresh fish fillet', 4)
SET IDENTITY_INSERT [dbo].[Foods] OFF
GO
SET IDENTITY_INSERT [dbo].[HealthStatuses] ON 

INSERT [dbo].[HealthStatuses] ([HealthStatusId], [PetId], [Weight], [LastCheckupDate], [VaccinationRecords], [Diseases]) VALUES (6, 1, 4.5, CAST(N'2023-12-01T00:00:00.0000000' AS DateTime2), N'Annual checkup done', N'None')
INSERT [dbo].[HealthStatuses] ([HealthStatusId], [PetId], [Weight], [LastCheckupDate], [VaccinationRecords], [Diseases]) VALUES (7, 2, 32, CAST(N'2023-11-20T00:00:00.0000000' AS DateTime2), N'Vaccinated for distemper', N'Feline flu')
INSERT [dbo].[HealthStatuses] ([HealthStatusId], [PetId], [Weight], [LastCheckupDate], [VaccinationRecords], [Diseases]) VALUES (8, 3, 6.1, CAST(N'2023-12-05T00:00:00.0000000' AS DateTime2), N'Updated rabies vaccine', N'None reported')
INSERT [dbo].[HealthStatuses] ([HealthStatusId], [PetId], [Weight], [LastCheckupDate], [VaccinationRecords], [Diseases]) VALUES (9, 4, 5.5, CAST(N'2023-11-28T00:00:00.0000000' AS DateTime2), N'Regular checkup', N'None')
SET IDENTITY_INSERT [dbo].[HealthStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Pets] ON 

INSERT [dbo].[Pets] ([PetId], [Name], [Species], [Age], [Gender], [UserId]) VALUES (1, N'Claire', N'Cat', 3, N'Male', 2)
INSERT [dbo].[Pets] ([PetId], [Name], [Species], [Age], [Gender], [UserId]) VALUES (2, N'Brew', N'Cat', 3, N'Male', 2)
INSERT [dbo].[Pets] ([PetId], [Name], [Species], [Age], [Gender], [UserId]) VALUES (3, N'Charlie', N'Dog', 2, N'Male', 1)
INSERT [dbo].[Pets] ([PetId], [Name], [Species], [Age], [Gender], [UserId]) VALUES (4, N'Chloe', N'Dog', 2, N'Female', 1)
INSERT [dbo].[Pets] ([PetId], [Name], [Species], [Age], [Gender], [UserId]) VALUES (5, N'Rıfkı', N'Dog', 3, N'Male', 1)
INSERT [dbo].[Pets] ([PetId], [Name], [Species], [Age], [Gender], [UserId]) VALUES (6, N'Naimie', N'Dog', 5, N'Female', 3)
INSERT [dbo].[Pets] ([PetId], [Name], [Species], [Age], [Gender], [UserId]) VALUES (7, N'Lillia', N'Dog', 2, N'Female', 2)
SET IDENTITY_INSERT [dbo].[Pets] OFF
GO
SET IDENTITY_INSERT [dbo].[SocialInteractions] ON 

INSERT [dbo].[SocialInteractions] ([SocialInteractionId], [StartTime], [Pet1], [Pet2]) VALUES (1, CAST(N'2023-12-23T06:52:50.6197743' AS DateTime2), 1, 2)
INSERT [dbo].[SocialInteractions] ([SocialInteractionId], [StartTime], [Pet1], [Pet2]) VALUES (2, CAST(N'2023-12-23T06:54:03.9045972' AS DateTime2), 1, 2)
INSERT [dbo].[SocialInteractions] ([SocialInteractionId], [StartTime], [Pet1], [Pet2]) VALUES (3, CAST(N'2023-12-23T07:07:59.5105666' AS DateTime2), 1, 3)
INSERT [dbo].[SocialInteractions] ([SocialInteractionId], [StartTime], [Pet1], [Pet2]) VALUES (4, CAST(N'2023-12-23T07:14:04.2912230' AS DateTime2), 1, 3)
SET IDENTITY_INSERT [dbo].[SocialInteractions] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainings] ON 

INSERT [dbo].[Trainings] ([TrainingId], [Name], [PetId]) VALUES (1, N'Oturma Komutu', 1)
SET IDENTITY_INSERT [dbo].[Trainings] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Email], [PasswordHash], [RegistrationDate]) VALUES (1, N'User1', N'user1@gmail.com', N'1', CAST(N'2023-12-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [PasswordHash], [RegistrationDate]) VALUES (2, N'Admin', N'admin@petapi.com', N'123456', CAST(N'2023-12-15T23:04:15.2280000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [PasswordHash], [RegistrationDate]) VALUES (3, N'reckol', N'reckol@gmail.com', N'123214', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_HealthStatuses_PetId]    Script Date: 31.12.2023 06:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_HealthStatuses_PetId] ON [dbo].[HealthStatuses]
(
	[PetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pets_UserId]    Script Date: 31.12.2023 06:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_Pets_UserId] ON [dbo].[Pets]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ((0)) FOR [PetId]
GO
ALTER TABLE [dbo].[Foods] ADD  DEFAULT ((0)) FOR [PetId]
GO
ALTER TABLE [dbo].[HealthStatuses]  WITH CHECK ADD  CONSTRAINT [FK_HealthStatuses_Pets_PetId] FOREIGN KEY([PetId])
REFERENCES [dbo].[Pets] ([PetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HealthStatuses] CHECK CONSTRAINT [FK_HealthStatuses_Pets_PetId]
GO
ALTER TABLE [dbo].[Pets]  WITH CHECK ADD  CONSTRAINT [FK_Pets_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Pets] CHECK CONSTRAINT [FK_Pets_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [PetApiDb] SET  READ_WRITE 
GO
