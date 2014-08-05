using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Radiostr.Data;
using Radiostr.Entities;
using Radiostr.Helpers;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class StationService
    {
        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository _repository;

        internal StationService(ISecurityHelper securityHelper, IRepository repository)
        {
            if (securityHelper == null) throw new ArgumentNullException("securityHelper");
            if (repository == null) throw new ArgumentNullException("repository");

            _securityHelper = securityHelper;
            _repository = repository;
        }

        /// <summary>
        /// Creates a Station and a Libray with the same name and description. Returns the Station Id and Library Id in a Tuble{int,int}.
        /// </summary>
        public async Task<Tuple<int, int>> CreateStationAndLibrary(Station station)
        {
            if (station == null) throw new ArgumentNullException("station");

            _securityHelper.Authenticate();

            const string insertStationSql = @"insert into Station (Name, Description, Url, StationOwnerId, WhenCreated) 
                                 values (@name, @description, @url, @stationOwnerId, @whenCreated);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";
            var stationResult =
                await
                    _repository.Query<int>(insertStationSql,
                        new { station.Name, station.Description, station.Url, station.StationOwnerId, whenCreated = DateTime.Now });
            int stationId = stationResult.ToArray()[0];
            Trace.TraceInformation("inserted station {0}, id = {1}", station, stationId);

            const string insertLibrarySql = @"insert into Library (Name, Description, StationId, WhenCreated) 
                                 values (@name, @description, @stationId, @whenCreated);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";
            var libraryResult = await _repository.Query<int>(insertLibrarySql, new { station.Name, station.Description, stationId, whenCreated = DateTime.Now });
            int libraryId = libraryResult.ToArray()[0];
            Trace.TraceInformation("inserted library name = {0}, stationId = {1}, id = {2}", station.Name, stationId, libraryId);

            return new Tuple<int, int>(stationId, libraryId);
        }

        public static StationService GetService()
        {
            return new StationService(new MockSecurityHelper(), new RadiostrRepository(new RadiostrDbConnection()));    //TODO: Don't mock security helper
        }
    }
}
