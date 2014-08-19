using System;
using System.Linq;
using System.Threading.Tasks;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Model;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class SimpleScheduleSelector : ISelector
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository _repository;
        private readonly ITrackModelService _trackService;
        private readonly IScheduleService _scheduleService;

        internal SimpleScheduleSelector(ISecurityHelper securityHelper, IRepository repository, ITrackModelService trackService,
            IScheduleService scheduleService)
        {
            if (securityHelper == null) throw new ArgumentNullException("securityHelper");
            if (repository == null) throw new ArgumentNullException("repository");
            if (trackService == null) throw new ArgumentNullException("trackService");

            _securityHelper = securityHelper;
            _repository = repository;
            _trackService = trackService;
            _scheduleService = scheduleService;
        }

        public async Task<Schedule> Select(string stationId, int[] libraryIds, int trackCount)
        {
            if (trackCount < 1 || trackCount > 40) throw new ArgumentOutOfRangeException("trackCount", "Must be between 1 and 40");
            _securityHelper.Authenticate();

            // Check libraries are valid for stationId.
            const string stationSql = "select stationId from library where id in @libraryIds";
            var stationIds = (await _repository.Query<int>(stationSql, new { libraryIds })).ToList();
            if (stationIds.Count != libraryIds.Length || stationIds.Any(s => s.ToString() != stationId))
            {
                throw new InvalidOperationException(string.Format(
                    "Not all libraryIds ({0}) are valid for StationId {1}", string.Join(",", libraryIds), stationId));
            }

            // TODO: this will be a more complex selection algorithm
            const string sql = @"   select top(@trackCount) TrackId
                                    from LibraryTrack 
                                    where libraryId in @libraryIds";

            var trackIds = await _repository.Query<int>(sql, new {trackCount, libraryIds, stationId});
            var tracks = await _trackService.GetTracks(trackIds.ToArray());
            var schedule = _scheduleService.CreateSchedule(stationId, tracks);

            return schedule;
        }

        public Task<Schedule> Select(string stationId, int[] libraryIds, TimeSpan duration)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> Select(string stationId, int[] libraryIds, DateTime startTime, DateTimePrecision precision, TimeSpan duration)
        {
            throw new NotImplementedException();
        }

        public static SimpleScheduleSelector GetService()
        {
            return new SimpleScheduleSelector(new MockSecurityHelper(),
                new RadiostrRepository(new RadiostrDbConnection()), TrackModelService.CreateTrackService(),
                ScheduleService.GetService());
        }
    }
}
