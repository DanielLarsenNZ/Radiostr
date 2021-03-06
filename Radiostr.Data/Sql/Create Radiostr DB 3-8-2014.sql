ALTER TABLE [dbo].[TrackUri] DROP CONSTRAINT [FK_TrackUri_Track]
GO
ALTER TABLE [dbo].[TrackUri] DROP CONSTRAINT [FK_TrackUri_Source]
GO
ALTER TABLE [dbo].[TrackUri] DROP CONSTRAINT [FK_TrackUri_Library]
GO
ALTER TABLE [dbo].[TrackAlbum] DROP CONSTRAINT [FK_TrackAlbum_Track]
GO
ALTER TABLE [dbo].[TrackAlbum] DROP CONSTRAINT [FK_TrackAlbum_Album]
GO
ALTER TABLE [dbo].[Track] DROP CONSTRAINT [FK_Track_Artist]
GO
ALTER TABLE [dbo].[Station] DROP CONSTRAINT [FK_Station_User]
GO
ALTER TABLE [dbo].[PlaylistTrack] DROP CONSTRAINT [FK_PlaylistTrack_Track]
GO
ALTER TABLE [dbo].[PlaylistTrack] DROP CONSTRAINT [FK_PlaylistTrack_Playlist]
GO
ALTER TABLE [dbo].[Playlist] DROP CONSTRAINT [FK_Playlist_Station]
GO
ALTER TABLE [dbo].[Playlist] DROP CONSTRAINT [FK_Playlist_Playlist]
GO
ALTER TABLE [dbo].[LibraryTrackTag] DROP CONSTRAINT [FK_LibraryTrackTag_Track]
GO
ALTER TABLE [dbo].[LibraryTrackTag] DROP CONSTRAINT [FK_LibraryTrackTag_Tag]
GO
ALTER TABLE [dbo].[LibraryTrackTag] DROP CONSTRAINT [FK_LibraryTrackTag_Library]
GO
ALTER TABLE [dbo].[LibraryTrack] DROP CONSTRAINT [FK_LibraryTrack_Track]
GO
ALTER TABLE [dbo].[LibraryTrack] DROP CONSTRAINT [FK_LibraryTrack_Library]
GO
ALTER TABLE [dbo].[Library] DROP CONSTRAINT [FK_Library_Station]
GO
ALTER TABLE [dbo].[ArtistUri] DROP CONSTRAINT [FK_ArtistUri_Artist]
GO
ALTER TABLE [dbo].[AlbumUri] DROP CONSTRAINT [FK_AlbumUri_Album]
GO
ALTER TABLE [dbo].[Album] DROP CONSTRAINT [FK_Album_Artist]
GO
/****** Object:  Index [IX_TrackUri_Uri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP INDEX [IX_TrackUri_Uri] ON [dbo].[TrackUri]
GO
/****** Object:  Index [IX_Tag_Name]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP INDEX [IX_Tag_Name] ON [dbo].[Tag]
GO
/****** Object:  Index [IX_ArtistUri_Uri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP INDEX [IX_ArtistUri_Uri] ON [dbo].[ArtistUri]
GO
/****** Object:  Index [IX_AlbumUri_Uri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP INDEX [IX_AlbumUri_Uri] ON [dbo].[AlbumUri]
GO
/****** Object:  Index [IX_Album_ArtistId_Title]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP INDEX [IX_Album_ArtistId_Title] ON [dbo].[Album]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[TrackUri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[TrackUri]
GO
/****** Object:  Table [dbo].[TrackAlbum]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[TrackAlbum]
GO
/****** Object:  Table [dbo].[Track]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[Track]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[Tag]
GO
/****** Object:  Table [dbo].[Station]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[Station]
GO
/****** Object:  Table [dbo].[Source]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[Source]
GO
/****** Object:  Table [dbo].[PlaylistTrack]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[PlaylistTrack]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[Playlist]
GO
/****** Object:  Table [dbo].[LibraryTrackTag]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[LibraryTrackTag]
GO
/****** Object:  Table [dbo].[LibraryTrack]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[LibraryTrack]
GO
/****** Object:  Table [dbo].[Library]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[Library]
GO
/****** Object:  Table [dbo].[ArtistUri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[ArtistUri]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[Artist]
GO
/****** Object:  Table [dbo].[AlbumUri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[AlbumUri]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 3/08/2014 9:07:17 p.m. ******/
DROP TABLE [dbo].[Album]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Table [dbo].[AlbumUri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AlbumUri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AlbumId] [int] NOT NULL,
	[Uri] [varchar](500) NOT NULL,
 CONSTRAINT [PK_AlbumUri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Table [dbo].[ArtistUri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArtistUri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[Uri] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ArtistUri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Library]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Table [dbo].[LibraryTrack]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Table [dbo].[LibraryTrackTag]    Script Date: 3/08/2014 9:07:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibraryTrackTag](
	[TrackId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[LibraryId] [int] NOT NULL,
 CONSTRAINT [PK_LibraryTrackTag] PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC,
	[TagId] ASC,
	[LibraryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Table [dbo].[PlaylistTrack]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Table [dbo].[Source]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Table [dbo].[Station]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Table [dbo].[Tag]    Script Date: 3/08/2014 9:07:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Track]    Script Date: 3/08/2014 9:07:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](400) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrackAlbum]    Script Date: 3/08/2014 9:07:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackAlbum](
	[TrackId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
 CONSTRAINT [PK_TrackAlbum] PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC,
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrackUri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
/****** Object:  Index [IX_Album_ArtistId_Title]    Script Date: 3/08/2014 9:07:17 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Album_ArtistId_Title] ON [dbo].[Album]
(
	[ArtistId] ASC,
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AlbumUri_Uri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AlbumUri_Uri] ON [dbo].[AlbumUri]
(
	[Uri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ArtistUri_Uri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ArtistUri_Uri] ON [dbo].[ArtistUri]
(
	[Uri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Tag_Name]    Script Date: 3/08/2014 9:07:17 p.m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tag_Name] ON [dbo].[Tag]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TrackUri_Uri]    Script Date: 3/08/2014 9:07:17 p.m. ******/
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
ALTER TABLE [dbo].[AlbumUri]  WITH CHECK ADD  CONSTRAINT [FK_AlbumUri_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([Id])
GO
ALTER TABLE [dbo].[AlbumUri] CHECK CONSTRAINT [FK_AlbumUri_Album]
GO
ALTER TABLE [dbo].[ArtistUri]  WITH CHECK ADD  CONSTRAINT [FK_ArtistUri_Artist] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([Id])
GO
ALTER TABLE [dbo].[ArtistUri] CHECK CONSTRAINT [FK_ArtistUri_Artist]
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
ALTER TABLE [dbo].[LibraryTrackTag]  WITH CHECK ADD  CONSTRAINT [FK_LibraryTrackTag_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([Id])
GO
ALTER TABLE [dbo].[LibraryTrackTag] CHECK CONSTRAINT [FK_LibraryTrackTag_Library]
GO
ALTER TABLE [dbo].[LibraryTrackTag]  WITH CHECK ADD  CONSTRAINT [FK_LibraryTrackTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[LibraryTrackTag] CHECK CONSTRAINT [FK_LibraryTrackTag_Tag]
GO
ALTER TABLE [dbo].[LibraryTrackTag]  WITH CHECK ADD  CONSTRAINT [FK_LibraryTrackTag_Track] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Track] ([Id])
GO
ALTER TABLE [dbo].[LibraryTrackTag] CHECK CONSTRAINT [FK_LibraryTrackTag_Track]
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
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Artist] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([Id])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Artist]
GO
ALTER TABLE [dbo].[TrackAlbum]  WITH CHECK ADD  CONSTRAINT [FK_TrackAlbum_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([Id])
GO
ALTER TABLE [dbo].[TrackAlbum] CHECK CONSTRAINT [FK_TrackAlbum_Album]
GO
ALTER TABLE [dbo].[TrackAlbum]  WITH CHECK ADD  CONSTRAINT [FK_TrackAlbum_Track] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Track] ([Id])
GO
ALTER TABLE [dbo].[TrackAlbum] CHECK CONSTRAINT [FK_TrackAlbum_Track]
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
