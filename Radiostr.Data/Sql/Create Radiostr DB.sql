USE [master]
GO
/****** Object:  Database [Radiostr]    Script Date: 18/04/2014 9:34:15 p.m. ******/
CREATE DATABASE [Radiostr]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Radiostr', FILENAME = N'C:\Users\dlarsen\Radiostr.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Radiostr_log', FILENAME = N'C:\Users\dlarsen\Radiostr_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Radiostr] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Radiostr].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Radiostr] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Radiostr] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Radiostr] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Radiostr] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Radiostr] SET ARITHABORT OFF 
GO
ALTER DATABASE [Radiostr] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Radiostr] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Radiostr] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Radiostr] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Radiostr] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Radiostr] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Radiostr] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Radiostr] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Radiostr] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Radiostr] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Radiostr] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Radiostr] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Radiostr] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Radiostr] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Radiostr] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Radiostr] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Radiostr] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Radiostr] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Radiostr] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Radiostr] SET  MULTI_USER 
GO
ALTER DATABASE [Radiostr] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Radiostr] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Radiostr] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Radiostr] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Radiostr]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[ArtistId] [int] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artist]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Library]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
	[StationId] [int] NOT NULL,
 CONSTRAINT [PK_Library] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LibraryTrack]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibraryTrack](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LibraryId] [int] NOT NULL,
	[TrackId] [int] NOT NULL,
 CONSTRAINT [PK_LibraryTrack] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StationId] [int] NOT NULL,
	[StartDateTime] [datetime] NULL,
	[Number] [int] NOT NULL,
	[PreviousPlaylistId] [int] NULL,
 CONSTRAINT [PK_Playlist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlaylistTrack]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistTrack](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlaylistId] [int] NOT NULL,
	[TrackId] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_PlaylistTrack] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Source]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Source](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Url] [varchar](200) NULL,
 CONSTRAINT [PK_Source] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Station]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Station](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Url] [varchar](200) NULL,
	[WhenCreated] [datetime] NOT NULL,
	[StationOwnerId] [int] NOT NULL,
 CONSTRAINT [PK_Station] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Track]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](400) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[Duration] [datetime] NOT NULL,
	[AlbumId] [int] NOT NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrackUri]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TrackUri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrackId] [int] NOT NULL,
	[LibraryId] [int] NULL,
	[SourceId] [int] NOT NULL,
	[Uri] [varchar](500) NOT NULL,
 CONSTRAINT [PK_TrackUri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 18/04/2014 9:34:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Email] [varchar](200) NULL,
	[TwitterHandle] [varchar](200) NULL,
	[Url] [varchar](200) NULL,
	[WhenCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_Station] FOREIGN KEY([StationId])
REFERENCES [dbo].[Station] ([Id])
GO
ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_Station]
GO
ALTER TABLE [dbo].[LibraryTrack]  WITH CHECK ADD  CONSTRAINT [FK_LibraryTrack_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([Id])
GO
ALTER TABLE [dbo].[LibraryTrack] CHECK CONSTRAINT [FK_LibraryTrack_Library]
GO
ALTER TABLE [dbo].[LibraryTrack]  WITH CHECK ADD  CONSTRAINT [FK_LibraryTrack_Track] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Track] ([Id])
GO
ALTER TABLE [dbo].[LibraryTrack] CHECK CONSTRAINT [FK_LibraryTrack_Track]
GO
ALTER TABLE [dbo].[Playlist]  WITH CHECK ADD  CONSTRAINT [FK_Playlist_Playlist] FOREIGN KEY([PreviousPlaylistId])
REFERENCES [dbo].[Playlist] ([Id])
GO
ALTER TABLE [dbo].[Playlist] CHECK CONSTRAINT [FK_Playlist_Playlist]
GO
ALTER TABLE [dbo].[Playlist]  WITH CHECK ADD  CONSTRAINT [FK_Playlist_Station] FOREIGN KEY([StationId])
REFERENCES [dbo].[Station] ([Id])
GO
ALTER TABLE [dbo].[Playlist] CHECK CONSTRAINT [FK_Playlist_Station]
GO
ALTER TABLE [dbo].[PlaylistTrack]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTrack_Playlist] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[Playlist] ([Id])
GO
ALTER TABLE [dbo].[PlaylistTrack] CHECK CONSTRAINT [FK_PlaylistTrack_Playlist]
GO
ALTER TABLE [dbo].[PlaylistTrack]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTrack_Track] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Track] ([Id])
GO
ALTER TABLE [dbo].[PlaylistTrack] CHECK CONSTRAINT [FK_PlaylistTrack_Track]
GO
ALTER TABLE [dbo].[Station]  WITH CHECK ADD  CONSTRAINT [FK_Station_User] FOREIGN KEY([StationOwnerId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Station] CHECK CONSTRAINT [FK_Station_User]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([Id])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Album]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Artist] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([Id])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Artist]
GO
ALTER TABLE [dbo].[TrackUri]  WITH CHECK ADD  CONSTRAINT [FK_TrackUri_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([Id])
GO
ALTER TABLE [dbo].[TrackUri] CHECK CONSTRAINT [FK_TrackUri_Library]
GO
ALTER TABLE [dbo].[TrackUri]  WITH CHECK ADD  CONSTRAINT [FK_TrackUri_Source] FOREIGN KEY([SourceId])
REFERENCES [dbo].[Source] ([Id])
GO
ALTER TABLE [dbo].[TrackUri] CHECK CONSTRAINT [FK_TrackUri_Source]
GO
ALTER TABLE [dbo].[TrackUri]  WITH CHECK ADD  CONSTRAINT [FK_TrackUri_Track] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Track] ([Id])
GO
ALTER TABLE [dbo].[TrackUri] CHECK CONSTRAINT [FK_TrackUri_Track]
GO
USE [master]
GO
ALTER DATABASE [Radiostr] SET  READ_WRITE 
GO
