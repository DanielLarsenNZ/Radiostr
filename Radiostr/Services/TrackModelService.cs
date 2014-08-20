using System;
using System.Linq;
using System.Threading.Tasks;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Model;
using Radiostr.Model.Entities;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class TrackModelService : ITrackModelService
    {
        //TODO: This should be called TrackService and TrackService should be called something else.

        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository _repository;
        private readonly IArtistService _artistService;

        internal TrackModelService(ISecurityHelper securityHelper, IRepository repository, IArtistService artistService)
        {
            _securityHelper = securityHelper;
            _repository = repository;
            _artistService = artistService;
        }

        public async Task<TrackModel[]> GetTracks(int[] trackIds)
        {
            _securityHelper.Authenticate();

            // tracks
            const string sql = "select * from track where id in @trackIds";
            var tracks = (await _repository.Query<Track>(sql, new {trackIds})).ToList();

            // artists
            var artists = await _artistService.GetList(tracks.Select(t => t.ArtistId).Distinct().ToArray());

            // albums
            
            // track URIs

            // tags


            // project into TrackModel[]

            return tracks.Select(t => new TrackModel
            {
                Artist = artists.First(a => a.Id == t.ArtistId),
                Duration = t.Duration,
                Title = t.Title,
                
                // TODO ...
            }).ToArray();
        }

        public static TrackModelService CreateTrackService()
        {
            var db = new RadiostrDbConnection();
            return new TrackModelService(new MockSecurityHelper(), new RadiostrRepository(db),
                ArtistService.CreateArtistService());
        }
    }
}