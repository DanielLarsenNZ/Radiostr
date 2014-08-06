using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Radiostr.Model;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Model.Entities;
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
        private readonly RadiostrService<Album> _albumService;
        private readonly ILibraryTrackService _libraryTrackService;

        internal TrackImportService(ISecurityHelper securityHelper, ITrackSearchService trackSearchService, 
            ITrackService trackService, RadiostrService<Artist> artistService, ILibraryTrackService libraryTrackService,
            RadiostrService<Album> albumService) 
        {
            _securityHelper = securityHelper;
            _trackSearchService = trackSearchService;
            _trackService = trackService;
            _artistService = artistService;
            _libraryTrackService = libraryTrackService;
            _albumService = albumService;
        }

        /// <summary>
        /// Imports Tracks into a Library, returns a lists of messages.
        /// </summary>
        public async Task ImportTracks(TracksImportModel model)
        {
            _securityHelper.Authenticate();
            _securityHelper.Authorise(model.StationId, model.LibraryId);

            //var results = new List<string>();

            foreach (TrackModel track in model.Tracks)
            {
                Trace.TraceInformation("Importing track {0} into Library {1} for Station {2}",
                    new object[] {track, model.StationId, model.LibraryId});

                // does track already exist?
                var trackResult = await FindTrack(track);

                if (!trackResult.Found) Trace.TraceInformation("Track {0} was not found.", new object[] {track});

                // if not found, create the Track
                int trackId = trackResult.Found ? trackResult.TrackId : CreateTrack(trackResult, track);

                Trace.TraceInformation("TrackId = " + trackId);

                // does Track exist in library?
                if (! await _libraryTrackService.TrackExistsInLibrary(trackId, model.LibraryId))
                {
                    // Create LibraryTrack
                    int libraryTrackId = _libraryTrackService.Create(new LibraryTrack
                    {
                        LibraryId = model.LibraryId,
                        TrackId = trackId,
                        WhenAdded = DateTime.Now
                    });

                    Trace.TraceInformation("LibraryTrack created with Id = " + libraryTrackId);

                    Trace.TraceInformation("{0} added to Library {1}.", track, model.LibraryId);
                    continue;
                }

                Trace.TraceInformation("{0} already exists in Library {1}.", track, model.LibraryId);
            }
        }

        protected internal int CreateTrack(TrackSearchResult result, TrackModel track)
        {
            int artistId = result.ArtistId == 0
                ? _artistService.Create(new Artist {Name = track.Artist.Name})
                : result.ArtistId;
            
            if (result.AlbumId == 0)
            {
                Trace.TraceInformation("Creating Track Title = {0}, ArtistId = {1}, Album = {2}",
                    new object[] {track.Title, artistId, track.Album});

                if (track.Album == null || string.IsNullOrEmpty(track.Album.Name))
                {
                    // create a track without an Album
                    return _trackService.CreateTrack(artistId, track.Title, track.Uri, track.Duration);    
                }
                // create an album and a track
                int albumId = _albumService.Create(new Album { ArtistId = artistId, Title = track.Album.Name });
                return _trackService.CreateTrack(artistId, albumId, track.Title, track.Uri, track.Duration);    
            }

            Trace.TraceInformation("Creating Track Title = {0}, ArtistId = {1}, AlbumId = {2}",
                new object[] {track.Title, artistId, result.AlbumId});

            return _trackService.CreateTrack(artistId, result.AlbumId, track.Title, track.Uri, track.Duration);
        }

        protected internal async Task<TrackSearchResult> FindTrack(TrackModel track)
        {
            // find track by URI
            int trackId = await _trackSearchService.FindTrackByUri(track.Uri);

            if (trackId != 0)
            {
                Trace.TraceInformation("Track found by URI " + track.Uri);                
                return new TrackSearchResult {Found = true, TrackId = trackId};
            }

            // find track by title+artist+album
            return await _trackSearchService.FindTrack(track.Artist.Name, track.Title, track.Album.Name);
        }

        public static TrackImportService CreateTrackImportService()
        {
            var db = new RadiostrDbConnection();
            var helper = new MockSecurityHelper();

            return new TrackImportService(helper, new TrackSearchService(helper,
                new RadiostrRepository(db)),
                new TrackService(helper, new RadiostrRepository<Track>(db),
                new TrackAlbumRepository(db),  new RadiostrRepository<TrackUri>(db)),
                new RadiostrService<Artist>(helper, new RadiostrRepository<Artist>(db)),
                new LibraryTrackService(helper, new RadiostrRepository<LibraryTrack>(db)), 
                new RadiostrService<Album>(helper, new RadiostrRepository<Album>(db)));
        }
    }
}