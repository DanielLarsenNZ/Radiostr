using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Model.Entities;
using Radiostr.Repositories;
using Radiostr.Results;

namespace Radiostr.Services
{
    /// <summary>
    /// Finds Tracks using various criteria
    /// </summary>
    public class TrackSearchService : ITrackSearchService
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository _repository;

        internal TrackSearchService(ISecurityHelper securityHelper, IRepository repository)
        {
            _securityHelper = securityHelper;
            _repository = repository;
        }

        /// <summary>
        /// Finds Track by title, artist and duration.
        /// </summary>
        /// <returns>{Found, Message, ArtistId, AlbumId, TrackId}</returns>
        public async Task<TrackSearchResult> FindTrack(string artist, string title, string album)
        {
            if (string.IsNullOrEmpty(artist)) throw new ArgumentNullException("artist");
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (string.IsNullOrEmpty(album)) Trace.TraceInformation("No Album argument supplied to FindTrack()");
            _securityHelper.Authenticate();

            // find artist
            var items = await FindArtist(artist);
            var artistResults = items.ToList();

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
                    albumId = await FindAlbum(artistId, album);
                    if (albumId != 0) break;
                }

                if (albumId == 0)
                    Trace.TraceInformation("No album was found for artist {0} with name {1}", new object[] {artist, album});
            }

            // find track
            int trackId = albumId == 0 ? await FindTrack(artistId, title) : await FindTrack(artistId, title, albumId);
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

        protected internal async Task<int> FindTrack(int artistId, string title)
        {
            var results = await _repository
                .Query("select Id from Track where ArtistId = @artistId and Title = @title",
                    new {artistId, title});

            var items = results.ToList();

            if (!items.Any()) return 0;
            if (items.Count() > 1) throw new InvalidOperationException("Track records should be unique by artist and title.");

            return items[0].Id;
        }

        protected internal async Task<int> FindTrack(int artistId, string title, int albumId)
        {
            var results = await _repository
                .Query(@"   select * 
                            from Track 
	                            join TrackAlbum on Track.Id = TrackAlbum.TrackId
                            where Track.Title = @title
	                              and Track.ArtistId = @artistId
	                              and TrackAlbum.AlbumId = @albumId",
                    new {artistId, title, albumId});

            var items = results.ToList();

            if (!items.Any()) return 0;
            if (items.Count() > 1) throw new InvalidOperationException("Track records should be unique by artist, album and title.");

            return items[0].Id;
        }

        protected async Task<int> FindAlbum(int artistId, string album)
        {
            var result = await _repository.Query("select Id from Album where ArtistId = @artistId and Title = @album",
                new {artistId, album});
            var items = result.ToList();

            if (items.Count > 1) throw new InvalidOperationException("Album records should be unique by artist and title.");

            return items.Count == 0 ? 0 : items[0].Id;
        }

        protected internal async Task<IEnumerable<dynamic>> FindArtist(string artist)
        {
            return await _repository.Query("select Id from Artist where Name = @artist", new {artist});
        }

        /// <summary>
        /// Finds Track by URI
        /// </summary>
        /// <returns>TrackId or 0 if not found</returns>
        public async Task<int> FindTrackByUri(string[] uri)
        {
            _securityHelper.Authenticate();

            if (uri == null) return 0;

            var result = await _repository.Query<int>("select TrackId from TrackUri where Uri in (@uri)", new {uri});
            var items = result.ToList();

            if (!items.Any()) return 0;

            int trackId = items[0];
            if (items.Count > 1 && items.Any(i => i != trackId)) {
                //TODO: This method could be refactored/overloaded to return more than one Track.
                throw new InvalidOperationException(
                    string.Format("More than one Track was found with the URIs given. URIs = {1}, TrackIds = {0}",
                        string.Join(",", uri), string.Join(",", items)));
            }

            return trackId;
        }

        public static TrackSearchService CreateService()
        {
            return new TrackSearchService(new MockSecurityHelper(), new RadiostrRepository<Track>(new RadiostrDbConnection()));
        }

    }
}