using System;
using Radiostr.Data;
using Radiostr.Model;
using Radiostr.Helpers;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class StationService : IStationService
    {
        internal StationService(ISecurityHelper securityHelper, IRepository<Station> repository)
        {
            _securityHelper = securityHelper;
            _repository = repository;
        }

        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository<Station> _repository;

        public int Create(Station station)
        {
            if (station == null) throw new ArgumentNullException("station");

            _securityHelper.Authenticate();
            
            return _repository.Create(station);
        }

        public Station Get(int id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException("id");

            _securityHelper.Authenticate();

            return _repository.Get(id);
        }

        public void Update(Station station)
        {
            if (station == null) throw new ArgumentNullException("station");

            _securityHelper.Authenticate();

            _repository.Update(station);
        }

        public void Delete(int id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException("id");

            _securityHelper.Authenticate();

            _repository.Delete(id);
        }

        /// <summary>
        /// Public factory method, in lieu of IoC.
        /// </summary>
        public static StationService CreateStationService()
        {
            return new StationService(new MockSecurityHelper(), new Repository<Station>(new RadiostrDbConnection()));
        }
    }
}
