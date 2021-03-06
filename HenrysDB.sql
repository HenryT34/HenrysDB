USE [master]
GO
/****** Object:  Database [HenrysDB]    Script Date: 30.06.2022 13:25:39 ******/
CREATE DATABASE [HenrysDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HenrysDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HenrysDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HenrysDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HenrysDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HenrysDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HenrysDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HenrysDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HenrysDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HenrysDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HenrysDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HenrysDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HenrysDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HenrysDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HenrysDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HenrysDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HenrysDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HenrysDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HenrysDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HenrysDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HenrysDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HenrysDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HenrysDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HenrysDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HenrysDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HenrysDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HenrysDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HenrysDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HenrysDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HenrysDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HenrysDB] SET  MULTI_USER 
GO
ALTER DATABASE [HenrysDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HenrysDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HenrysDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HenrysDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HenrysDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HenrysDB', N'ON'
GO
ALTER DATABASE [HenrysDB] SET QUERY_STORE = OFF
GO
USE [HenrysDB]
GO
/****** Object:  User [COMSPOT\henry.tamm]    Script Date: 30.06.2022 13:25:39 ******/
CREATE USER [COMSPOT\henry.tamm] FOR LOGIN [COMSPOT\henry.tamm] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [API_User]    Script Date: 30.06.2022 13:25:39 ******/
CREATE USER [API_User] FOR LOGIN [API_User] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [COMSPOT\henry.tamm]
GO
ALTER ROLE [db_owner] ADD MEMBER [API_User]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 30.06.2022 13:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[RoomId] [int] NOT NULL,
	[ScheduleId] [int] NOT NULL,
	[TutorId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 30.06.2022 13:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 30.06.2022 13:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeCourseBeginning] [time](7) NOT NULL,
	[TimeCourseEnd] [time](7) NOT NULL,
	[DateDay] [date] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 30.06.2022 13:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourseMapping]    Script Date: 30.06.2022 13:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourseMapping](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_StudentCourseMapping_1] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tutor]    Script Date: 30.06.2022 13:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tutor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Tutor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO
ALTER TABLE [dbo].[Schedule] ADD  CONSTRAINT [DF_Schedule_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Schedule] ADD  CONSTRAINT [DF_Schedule_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO
ALTER TABLE [dbo].[StudentCourseMapping] ADD  CONSTRAINT [DF_StudentCourseMapping_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[StudentCourseMapping] ADD  CONSTRAINT [DF_StudentCourseMapping_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO
ALTER TABLE [dbo].[Tutor] ADD  CONSTRAINT [DF_Tutor_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Tutor] ADD  CONSTRAINT [DF_Tutor_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Room]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Schedule]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Tutor] FOREIGN KEY([TutorId])
REFERENCES [dbo].[Tutor] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Tutor]
GO
ALTER TABLE [dbo].[StudentCourseMapping]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourseMapping_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[StudentCourseMapping] CHECK CONSTRAINT [FK_StudentCourseMapping_Course]
GO
ALTER TABLE [dbo].[StudentCourseMapping]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourseMapping_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentCourseMapping] CHECK CONSTRAINT [FK_StudentCourseMapping_Student]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das ist eine Testtabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student'
GO
USE [master]
GO
ALTER DATABASE [HenrysDB] SET  READ_WRITE 
GO
