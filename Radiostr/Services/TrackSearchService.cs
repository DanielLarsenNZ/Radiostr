using System;
using System.Linq;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Models;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    /// <summary>
    /// Finds Tracks using various criteria
    /// </summary>
    public class TrackSearchService
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository<Track> _trackRepository;

        internal TrackSearchService(ISecurityHelper securityHelper, IRepository<Track> trackRepository)
        {
            _securityHelper = securityHelper;
            _trackRepository = trackRepository;
        }

        /// <summary>
        /// Finds Track by title, artist and duration.
        /// </summary>
        /// <returns>Track ID or 0 if not found.</returns>
        public dynamic FindTrack(string artist, string title, string album)
        {
            _securityHelper.Authenticate();

            var artistResults = FindArtist(artist);
            if (!artistResults.Found) return artistResults;

            // find album
            int albumId = 0;
            int artistId = 0;
            foreach (var artistResult in artistResults.Artists)
            {
                artistId = artistResult.ArtistId;
                var albumResult = FindAlbum(artistId, album);
                if (albumResult.Found)
                {
                    albumId = albumResult.AlbumId;
                    break;
                }
            }
            
            if (albumId == 0) return new {Found = false, Message = "Album not found", artistResults.Artists};

            // find track
            int trackId = FindTrack(artistId, albumId, title);
            if (trackId == 0)
                return new {Found = false, Message = "Track not found", ArtistId = artistId, AlbumId = albumId};

            return new {Found = true, ArtistId = artistId, AlbumId = albumId, TrackId = trackId};
        }

        protected internal int FindTrack(int artistId, int albumId, string title)
        {
            var results = _trackRepository
                .Query("select Id from Track where ArtistId = @artistId and AlbumId = @albumId and Title = @title",
                    new {artistId, albumId, title})
                .ToList();
            if (!results.Any()) return 0;
            if (results.Count() > 1) throw new InvalidOperationException("Track records should be unique by artist, album and title.");

            return results[0].Id;
        }

        protected internal dynamic FindAlbum(int artistId, string album)
        {
            var result = _trackRepository.Query("select Id from Album where ArtistId = @artistId and Title = @album",
                new {artistId, album})
                .ToList();
            if (!result.Any()) return new { Found = false, Message = "Album not found", AlbumId = 0 };
            if (result.Count > 1) throw new InvalidOperationException("Album records should be unique by artist and title.");

            return new { Found = true, AlbumId = result[0].Id };
        }

        protected internal dynamic FindArtist(string artist)
        {
            var results = _trackRepository.Query("select Id from Artist where Name = @artist", new { artist }).ToList();
            if (!results.Any()) return new {Found = false, Message = "Artist not found"};

            return new {Found = true, results.Count, Artists = results};
        }

        /// <summary>
        /// Finds Track by URI
        /// </summary>
        /// <returns>TrackId or 0 if not found</returns>
        public int FindTrack(string uri)
        {
            _securityHelper.Authenticate();

            var result = _trackRepository.Query("select TrackId from TrackUri where Uri = @uri", new {uri}).ToList();

            if (!result.Any()) return 0;
            
            if (result.Count > 1) throw new InvalidOperationException("TrackUri records should be unique.");
            
            return result[0].TrackId;
        }

        public static TrackSearchService CreateService()
        {
            return new TrackSearchService(new MockSecurityHelper(), new RadiostrRepository<Track>(new RadiostrDbConnection()));
        }

    }
}