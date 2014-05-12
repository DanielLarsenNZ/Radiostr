using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Radiostr.Data;
using Radiostr.Entities;
using Radiostr.Helpers;
using Radiostr.Models;
using Radiostr.Repositories;
using Radiostr.Results;
using Scale.Logger;

namespace Radiostr.Services
{
    /// <summary>
    /// Finds Tracks using various criteria
    /// </summary>
    public class TrackSearchService : ITrackSearchService
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository _repository;
        private readonly ILogger _log;

        internal TrackSearchService(ISecurityHelper securityHelper, IRepository repository, ILoggerRegistry loggerRegistry)
        {
            _securityHelper = securityHelper;
            _repository = repository;
            _log = loggerRegistry.Logger(loggerRegistry.MakeKey("Radiostr.Services", "TrackSearchService"));
        }

        /// <summary>
        /// Finds Track by title, artist and duration.
        /// </summary>
        /// <returns>{Found, Message, ArtistId, AlbumId, TrackId}</returns>
        public TrackSearchResult FindTrack(string artist, string title, string album)
        {
            if (string.IsNullOrEmpty(artist)) throw new ArgumentNullException("artist");
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (string.IsNullOrEmpty(album)) _log.Message("No Album argument supplied to FindTrack()");
            _securityHelper.Authenticate();

            // find artist
            var artistResults = FindArtist(artist).ToList();
            if (!artistResults.Any()) return new TrackSearchResult{Found = false, 
                Message = string.Format("Artist \"{0}\"", artist)};

            int albumId = 0;
            int artistId = 0;

            if (!string.IsNullOrEmpty(album))
            {
                // find album
                foreach (var artistResult in artistResults)
                {
                    artistId = artistResult.Id;
                    albumId = FindAlbum(artistId, album);
                    if (albumId != 0) break;
                }

                if (albumId == 0)
                    _log.Message("No album was found for artist {0} with name {1}", new object[] {artist, album});
            }

            // find track
            int trackId = albumId == 0 ? FindTrack(artistId, title) : FindTrack(artistId, title, albumId);
            if (trackId == 0)
                return new TrackSearchResult
                {
                    Found = false,
                    Message =
                        string.Format("No Track \"{0}\" found for Artist \"{1}\" and Album \"{2}\".", title, artist,
                            album),
                    ArtistId = artistId,
                    AlbumId = albumId
                };

            return new TrackSearchResult { Found = true, ArtistId = artistId, AlbumId = albumId, TrackId = trackId };
        }

        protected internal int FindTrack(int artistId, string title)
        {
            var results = _repository
                .Query("select Id from Track where ArtistId = @artistId and Title = @title",
                    new {artistId, title})
                .ToList();
            if (!results.Any()) return 0;
            if (results.Count() > 1) throw new InvalidOperationException("Track records should be unique by artist and title.");

            return results[0].Id;
        }

        protected internal int FindTrack(int artistId, string title, int albumId)
        {
            var results = _repository
                .Query(@"   select * 
                            from Track 
	                            join TrackAlbum on Track.Id = TrackAlbum.TrackId
                            where Track.Title = @title
	                              and Track.ArtistId = @artistId
	                              and TrackAlbum.AlbumId = @albumId",
                    new {artistId, title, albumId})
                .ToList();
            if (!results.Any()) return 0;
            if (results.Count() > 1) throw new InvalidOperationException("Track records should be unique by artist, album and title.");

            return results[0].Id;
        }

        protected int FindAlbum(int artistId, string album)
        {
            var result = _repository.Query("select Id from Album where ArtistId = @artistId and Title = @album",
                new {artistId, album})
                .ToList();
            if (result.Count > 1) throw new InvalidOperationException("Album records should be unique by artist and title.");

            return result.Count == 0 ? 0 : result[0].Id;
        }

        protected internal IEnumerable<dynamic> FindArtist(string artist)
        {
            return _repository.Query("select Id from Artist where Name = @artist", new {artist});
        }

        /// <summary>
        /// Finds Track by URI
        /// </summary>
        /// <returns>TrackId or 0 if not found</returns>
        public int FindTrackByUri(string uri)
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException("uri");

            _securityHelper.Authenticate();

            var result = _repository.Query("select TrackId from TrackUri where Uri = @uri", new {uri}).ToList();

            if (!result.Any()) return 0;
            
            if (result.Count > 1) throw new InvalidOperationException("TrackUri records should be unique.");
            
            return result[0].TrackId;
        }

        public static TrackSearchService CreateService()
        {
            return new TrackSearchService(new MockSecurityHelper(), new RadiostrRepository<Track>(new RadiostrDbConnection()), new LoggerRegistry());
        }

    }
}