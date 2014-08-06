using System;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Model.Entities;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class TrackService : RadiostrService<Track>, ITrackService
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly ITrackAlbumRepository _trackAlbumRepository;
        private readonly IRepository<TrackUri> _trackUriRepository;

        internal TrackService(ISecurityHelper securityHelper, IRepository<Track> trackRepository,
            ITrackAlbumRepository trackAlbumRepository, IRepository<TrackUri> trackUriRepository)
            :base(securityHelper, trackRepository)
        {
            _securityHelper = securityHelper;
            _trackAlbumRepository = trackAlbumRepository;
            _trackUriRepository = trackUriRepository;
        }

        public int CreateTrack(int artistId, int albumId, string track, string uri, int duration)
        {
            if (artistId == 0) throw new ArgumentNullException("artistId");
            if (string.IsNullOrEmpty(track)) throw new ArgumentNullException("track");
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException("uri");
            if (duration <= 0) throw new ArgumentOutOfRangeException("duration", "duration must be greater than zero.");

            _securityHelper.Authenticate();

            // Track
            int trackId = Create(new Track
            {
                ArtistId = artistId,
                Title = track,
                Duration = duration
            });

            // Track URI
            _trackUriRepository.Create(new TrackUri { TrackId = trackId, Uri = uri });

            // TrackAlbum
            if (albumId != 0) _trackAlbumRepository.Create(trackId, albumId);

            return trackId;
        }

        public int CreateTrack(int artistId, string track, string uri, int duration)
        {
            return CreateTrack(artistId, 0, track, uri, duration);
        }

        public static TrackService CreateTrackService()
        {
            var db = new RadiostrDbConnection();
            return new TrackService(new MockSecurityHelper(), new RadiostrRepository<Track>(db),
                new TrackAlbumRepository(db), new RadiostrRepository<TrackUri>(db));
        }
    }
}