using System;
using System.Threading.Tasks;
using Radiostr.Helpers;
using Radiostr.Model;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class SimpleScheduleSelector : ISelector
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository _repository;

        internal SimpleScheduleSelector(ISecurityHelper securityHelper, IRepository repository)
        {
            if (securityHelper == null) throw new ArgumentNullException("securityHelper");
            if (repository == null) throw new ArgumentNullException("repository");

            _securityHelper = securityHelper;
            _repository = repository;
        }

        public async Task<Schedule> Select(int stationId, int[] libraryIds, int trackCount)
        {
            if (trackCount < 1 || trackCount > 100) throw new ArgumentOutOfRangeException("trackCount", "Must be between 1 and 100");
            _securityHelper.Authenticate();

            const string sql = @"select top(@trackCount) TrackId
                                 from LibraryTrack lt 
                                 join Library l on lt.LibraryId = l.Id 
                                 where libraryId in (@libraryIds) and stationId = @stationId";

            var trackIds = await _repository.Query<int>(sql, new {trackCount, libraryIds, stationId});
            
            //TODO
            throw new NotImplementedException();
        }

        public Task<Schedule> Select(int stationId, int[] libraryIds, TimeSpan duration)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> Select(int stationId, int[] libraryIds, DateTime startTime, DateTimePrecision precision, TimeSpan duration)
        {
            throw new NotImplementedException();
        }
    }
}
