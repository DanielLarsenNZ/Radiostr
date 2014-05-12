using System;
using System.Collections.Generic;
using Scale.Logger;
using Radiostr.Data;
using Radiostr.Entities;
using Radiostr.Helpers;
using Radiostr.Models;
using Radiostr.Repositories;
using Radiostr.Results;

namespace Radiostr.Services
{
    /// <summary>
    /// Service for importing Tracks into a Station's Library.
    /// </summary>
    public class TrackImportService : ITrackImportService
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly ITrackSearchService _trackSearchService;
        private readonly ITrackService _trackService;
        private readonly RadiostrService<Artist> _artistService;
        private readonly ILibraryTrackService _libraryTrackService;
        private readonly ILogger _log;
        private readonly IMbidHelper _mbidHelper;

        internal TrackImportService(ISecurityHelper securityHelper, ITrackSearchService trackSearchService, 
            ITrackService trackService, RadiostrService<Artist> artistService, ILibraryTrackService libraryTrackService,
            ILoggerRegistry logRegistry, IMbidHelper mbidHelper) 
        {
            _securityHelper = securityHelper;
            _trackSearchService = trackSearchService;
            _trackService = trackService;
            _artistService = artistService;
            _libraryTrackService = libraryTrackService;
            _mbidHelper = mbidHelper;

            _log = logRegistry.Logger(logRegistry.MakeKey("Radiostr.Services", "TrackImportService"));
        }

        /// <summary>
        /// Imports Tracks into a Library, returns a lists of messages.
        /// </summary>
        public string[] ImportTracks(TrackImportModel model)
        {
            _securityHelper.Authenticate();
            _securityHelper.Authorise(model.StationId, model.LibraryId);

            var results = new List<string>();

            foreach (TrackModel track in model.Tracks)
            {
                _log.Message("Importing track {0} into Library {1} for Station {2}",
                    new object[] {track, model.StationId, model.LibraryId});

                // does track already exist?
                var trackResult = FindTrack(track);

                if (!trackResult.Found) _log.Message("Track {0} was not found.", new object[] {track});

                // if not found, create the Track
                int trackId = trackResult.Found ? trackResult.TrackId : CreateTrack(trackResult, track);

                _log.Message("TrackId = " + trackId);

                // does Track exist in library?
                if (!_libraryTrackService.TrackExistsInLibrary(trackId, model.LibraryId))
                {
                    // Create LibraryTrack
                    int libraryTrackId = _libraryTrackService.Create(new LibraryTrack
                    {
                        LibraryId = model.LibraryId,
                        TrackId = trackId,
                        WhenAdded = DateTime.Now
                    });

                    _log.Message("LibraryTrack created with Id = " + libraryTrackId);

                    results.Add(string.Format("{0} added to Library {1}.", track, model.LibraryId));
                    continue;
                }

                results.Add(string.Format("{0} already exists in Library {1}.", track, model.LibraryId));
            }

            return results.ToArray();
        }

        protected internal int CreateTrack(TrackSearchResult result, TrackModel track)
        {
            int artistId = result.ArtistId == 0
                ? _artistService.Create(new Artist {Name = track.Artist.Name})
                : result.ArtistId;
            
            if (result.AlbumId == 0)
            {
                _log.Message("Creating Track Title = {0}, ArtistId = {1}, Album = {2}",
                    new object[] {track.Title, artistId, track.Album});

                return _trackService.CreateTrack(artistId, track.Album, track.Title, track.Uri, track.Duration);
            }

            _log.Message("Creating Track Title = {0}, ArtistId = {1}, AlbumId = {2}",
                new object[] {track.Title, artistId, result.AlbumId});

            return _trackService.CreateTrack(artistId, result.AlbumId, track.Title, track.Uri, track.Duration);
        }

        protected internal TrackSearchResult FindTrack(TrackModel track)
        {
            // find track by URI
            int trackId = _trackSearchService.FindTrackByUri(track.Uri);

            if (trackId != 0)
            {
                _log.Message("Track found by URI " + track.Uri);                
                return new TrackSearchResult {Found = true, TrackId = trackId};
            }

            // find track by MBID
            if (!string.IsNullOrEmpty(track.Mbid))
            {
                // re-using trackId
                trackId = _trackSearchService.FindTrackByUri(_mbidHelper.GetMbidUri(track.Mbid));

                if (trackId != 0)
                {
                    _log.Message("Track found by MBID " + track.Mbid);
                    return new TrackSearchResult { Found = true, TrackId = trackId };
                }
            }

            // find track by title+artist+album
            return _trackSearchService.FindTrack(track.Artist.Name, track.Title, track.Album);
        }

        public static TrackImportService CreateTrackImportService()
        {
            var db = new RadiostrDbConnection();
            var helper = new MockSecurityHelper();

            return new TrackImportService(helper, new TrackSearchService(helper,
                new RadiostrRepository(db), new LoggerRegistry()),
                new TrackService(helper, new RadiostrRepository<Track>(db),
                new RadiostrRepository<Album>(db), new RadiostrRepository<TrackUri>(db)),
                new RadiostrService<Artist>(helper, new RadiostrRepository<Artist>(db)),
                new LibraryTrackService(helper, new RadiostrRepository<LibraryTrack>(db)), new LoggerRegistry(), new MbidHelper());
        }
    }
}