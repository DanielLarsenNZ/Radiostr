using System;
using Radiostr.Data;
using Radiostr.Entities;
using Radiostr.Helpers;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class TrackService : RadiostrService<Track>, ITrackService
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository<Album> _albumRepository;
        private readonly IRepository<TrackUri> _trackUriRepository;

        internal TrackService(ISecurityHelper securityHelper, IRepository<Track> trackRepository,
            IRepository<Album> albumRepository, IRepository<TrackUri> trackUriRepository)
            :base(securityHelper, trackRepository)
        {
            _securityHelper = securityHelper;
            _albumRepository = albumRepository;
            _trackUriRepository = trackUriRepository;
        }

        public int CreateTrack(int artistId, int albumId, string track, string uri, float duration)
        {
            if (artistId == 0) throw new ArgumentNullException("artistId");
            if (albumId == 0) throw new ArgumentNullException("albumId");
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

            return trackId;
        }

        public int CreateTrack(int artistId, string album, string track, string uri, float duration)
        {
            if (artistId == 0) throw new ArgumentNullException("artistId");
            if (string.IsNullOrEmpty(album)) throw new ArgumentNullException("album");
            if (string.IsNullOrEmpty(track)) throw new ArgumentNullException("track");
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException("uri");
            if (duration <= 0) throw new ArgumentOutOfRangeException("duration", "duration must be greater than zero.");

            _securityHelper.Authenticate();

            int albumId = _albumRepository.Create(new Album { Title = album, ArtistId = artistId });

            return CreateTrack(artistId, albumId, track, uri, duration);
        }

        public static TrackService CreateTrackService()
        {
            var db = new RadiostrDbConnection();
            return new TrackService(new MockSecurityHelper(), new RadiostrRepository<Track>(db),
                new RadiostrRepository<Album>(db), new RadiostrRepository<TrackUri>(db));
        }
    }
}