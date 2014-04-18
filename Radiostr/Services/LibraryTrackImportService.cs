using System;
using System.Security.Cryptography.X509Certificates;
using Radiostr.Helpers;
using Radiostr.Models;
using Radiostr.Repositories;
using Radiostr.Results;

namespace Radiostr.Services
{
    /// <summary>
    /// Imports Tracks into a Library
    /// </summary>
    public class LibraryTrackImportService 
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository<Track> _trackRepository;

        internal LibraryTrackImportService(ISecurityHelper securityHelper, IRepository<Track> trackRepository) 
        {
            _securityHelper = securityHelper;
            _trackRepository = trackRepository;     
        }

        /*
         * dynamic trackModel = new
            {
                StationId = stationId,
                LibraryId = 456,
                Tags = "nights, reggae",
                Tracks = new []
                {
                    new
                    {
                        Title = "Title1",
                        Artist = "Artist1",
                        Duration = "3:30",
                        Uri = "http://spotify.com/track/tr67uw783y",
                        Tags = "dub"
                    }
                }
            };
         * */

        public Result ImportTracks(dynamic model)
        {
            _securityHelper.Authenticate(model.StationId, model.LibraryId);

            var result = new Result();
            foreach (dynamic track in model.Tracks)
            {
                // does track already exist?

                // Create Track

                // does Track exist in library?

                // Create LibraryTrack

            }

            throw new NotImplementedException();
        }
        
        protected internal Result LookupTrack(dynamic track)
        {
            throw new NotImplementedException();
        }
    }
}