USE [master]
GO
/****** Object:  Database [Radiostr_Test]    Script Date: 7/05/2014 8:55:29 p.m. ******/
CREATE DATABASE [Radiostr_Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Radiostr', FILENAME = N'C:\Users\dlarsen\Dropbox\Github\Radiostr\Radiostr.Data\App_Data\Radiostr.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Radiostr_log', FILENAME = N'C:\Users\dlarsen\Dropbox\Github\Radiostr\Radiostr.Data\App_Data\Radiostr_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Radiostr_Test] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Radiostr_Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Radiostr_Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Radiostr_Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Radiostr_Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Radiostr_Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Radiostr_Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Radiostr_Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Radiostr_Test] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Radiostr_Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Radiostr_Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Radiostr_Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Radiostr_Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Radiostr_Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Radiostr_Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Radiostr_Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Radiostr_Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Radiostr_Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Radiostr_Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Radiostr_Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Radiostr_Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Radiostr_Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Radiostr_Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Radiostr_Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Radiostr_Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Radiostr_Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Radiostr_Test] SET  MULTI_USER 
GO
ALTER DATABASE [Radiostr_Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Radiostr_Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Radiostr_Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Radiostr_Test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Radiostr_Test]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 7/05/2014 8:55:29 p.m. ******/
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
/****** Object:  Table [dbo].[Artist]    Script Date: 7/05/2014 8:55:29 p.m. ******/
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
/****** Object:  Table [dbo].[Library]    Script Date: 7/05/2014 8:55:29 p.m. ******/
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
/****** Object:  Table [dbo].[LibraryTrack]    Script Date: 7/05/2014 8:55:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibraryTrack](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LibraryId] [int] NOT NULL,
	[TrackId] [int] NOT NULL,
	[WhenAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_LibraryTrack] PRIMARY KEY CLUSTERED 
(
	[LibraryId] ASC,
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 7/05/2014 8:55:29 p.m. ******/
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
/****** Object:  Table [dbo].[PlaylistTrack]    Script Date: 7/05/2014 8:55:29 p.m. ******/
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
/****** Object:  Table [dbo].[Source]    Script Date: 7/05/2014 8:55:29 p.m. ******/
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
/****** Object:  Table [dbo].[Station]    Script Date: 7/05/2014 8:55:29 p.m. ******/
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
/****** Object:  Table [dbo].[Track]    Script Date: 7/05/2014 8:55:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](400) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[Duration] [float] NOT NULL,
	[AlbumId] [int] NOT NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrackUri]    Script Date: 7/05/2014 8:55:29 p.m. ******/
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
	[SourceId] [int] NULL,
	[Uri] [varchar](500) NOT NULL,
 CONSTRAINT [PK_TrackUri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/05/2014 8:55:29 p.m. ******/
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
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Album_ArtistId_Title]    Script Date: 7/05/2014 8:55:29 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Album_ArtistId_Title] ON [dbo].[Album]
(
	[ArtistId] ASC,
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Track]    Script Date: 7/05/2014 8:55:29 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Track] ON [dbo].[Track]
(
	[ArtistId] ASC,
	[AlbumId] ASC,
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TrackUri_Uri]    Script Date: 7/05/2014 8:55:29 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TrackUri_Uri] ON [dbo].[TrackUri]
(
	[Uri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Artist] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([Id])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Artist]
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
ALTER DATABASE [Radiostr_Test] SET  READ_WRITE 
GO
