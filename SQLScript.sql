USE [master]
GO
/****** Object:  Database [MusicDatabaseDavid]    Script Date: 13 Oct 2020 23:25:05 ******/
CREATE DATABASE [MusicDatabaseDavid]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MusicDatabaseDavid', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MusicDatabaseDavid.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MusicDatabaseDavid_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MusicDatabaseDavid_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MusicDatabaseDavid] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MusicDatabaseDavid].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MusicDatabaseDavid] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET ARITHABORT OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MusicDatabaseDavid] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MusicDatabaseDavid] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MusicDatabaseDavid] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MusicDatabaseDavid] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET RECOVERY FULL 
GO
ALTER DATABASE [MusicDatabaseDavid] SET  MULTI_USER 
GO
ALTER DATABASE [MusicDatabaseDavid] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MusicDatabaseDavid] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MusicDatabaseDavid] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MusicDatabaseDavid] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MusicDatabaseDavid] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MusicDatabaseDavid', N'ON'
GO
ALTER DATABASE [MusicDatabaseDavid] SET QUERY_STORE = OFF
GO
USE [MusicDatabaseDavid]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 13 Oct 2020 23:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[YearOfBirth] [int] NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 13 Oct 2020 23:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecordArtists]    Script Date: 13 Oct 2020 23:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecordArtists](
	[RecordId] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
 CONSTRAINT [PK_RecordArtists] PRIMARY KEY CLUSTERED 
(
	[RecordId] ASC,
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Records]    Script Date: 13 Oct 2020 23:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Records](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[YearOfRelease] [int] NULL,
	[GenreId] [int] NULL,
 CONSTRAINT [PK_Records] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([Id], [Name], [YearOfBirth]) VALUES (1, N'Beethoven', 1827)
INSERT [dbo].[Artists] ([Id], [Name], [YearOfBirth]) VALUES (2, N'Bob Dylan', 1941)
INSERT [dbo].[Artists] ([Id], [Name], [YearOfBirth]) VALUES (3, N'Avicii', 1989)
INSERT [dbo].[Artists] ([Id], [Name], [YearOfBirth]) VALUES (4, N'Calvin Harris', 1984)
INSERT [dbo].[Artists] ([Id], [Name], [YearOfBirth]) VALUES (5, N'Ellie Goulding', 1986)
INSERT [dbo].[Artists] ([Id], [Name], [YearOfBirth]) VALUES (6, N'test', 3)
INSERT [dbo].[Artists] ([Id], [Name], [YearOfBirth]) VALUES (7, N'as', 33)
INSERT [dbo].[Artists] ([Id], [Name], [YearOfBirth]) VALUES (8, N'h', 2000)
INSERT [dbo].[Artists] ([Id], [Name], [YearOfBirth]) VALUES (10, N'Bob Dylan', 1941)
SET IDENTITY_INSERT [dbo].[Artists] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Pop')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Rock')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Rap')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Hip-Hop')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Punk')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (6, N'Metal')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (7, N'Classical')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (8, N'Folk Rock')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (9, N'EDM')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (10, N'Tests2')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (11, N'Metal')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (12, N'Folk Rock')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (13, N'Hip-Hop')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (14, N'Punk')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
INSERT [dbo].[RecordArtists] ([RecordId], [ArtistId]) VALUES (1, 2)
INSERT [dbo].[RecordArtists] ([RecordId], [ArtistId]) VALUES (2, 1)
INSERT [dbo].[RecordArtists] ([RecordId], [ArtistId]) VALUES (3, 3)
INSERT [dbo].[RecordArtists] ([RecordId], [ArtistId]) VALUES (4, 4)
INSERT [dbo].[RecordArtists] ([RecordId], [ArtistId]) VALUES (4, 5)
GO
SET IDENTITY_INSERT [dbo].[Records] ON 

INSERT [dbo].[Records] ([Id], [Name], [YearOfRelease], [GenreId]) VALUES (1, N'Like A Rolling Stone', 1965, 8)
INSERT [dbo].[Records] ([Id], [Name], [YearOfRelease], [GenreId]) VALUES (2, N'Moonlight sonata', 1827, 7)
INSERT [dbo].[Records] ([Id], [Name], [YearOfRelease], [GenreId]) VALUES (3, N'Hey Brother', 2012, 1)
INSERT [dbo].[Records] ([Id], [Name], [YearOfRelease], [GenreId]) VALUES (4, N'Outside', 2014, 9)
SET IDENTITY_INSERT [dbo].[Records] OFF
GO
ALTER TABLE [dbo].[RecordArtists]  WITH CHECK ADD  CONSTRAINT [FK_RecordArtists_Artists_ArtistId] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecordArtists] CHECK CONSTRAINT [FK_RecordArtists_Artists_ArtistId]
GO
ALTER TABLE [dbo].[RecordArtists]  WITH CHECK ADD  CONSTRAINT [FK_RecordArtists_Records_RecordId] FOREIGN KEY([RecordId])
REFERENCES [dbo].[Records] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecordArtists] CHECK CONSTRAINT [FK_RecordArtists_Records_RecordId]
GO
ALTER TABLE [dbo].[Records]  WITH CHECK ADD  CONSTRAINT [FK_Records_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Records] CHECK CONSTRAINT [FK_Records_Genres]
GO
USE [master]
GO
ALTER DATABASE [MusicDatabaseDavid] SET  READ_WRITE 
GO
