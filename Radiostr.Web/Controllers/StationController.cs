using System;
using System.Collections.Generic;
using System.Web.Http;
using Radiostr.Model;
using Radiostr.Services;

namespace Radiostr.Web.Controllers
{
    public class StationController : ApiController
    {
        private readonly IStationService _service = StationService.CreateStationService();

        // GET api/station
        public IEnumerable<Station> Get()
        {
            throw new NotSupportedException();
        }

        // GET api/station/5
        public Station Get(int id)
        {
            return _service.Get(id);
        }

        // POST api/station
        public int Post([FromBody]Station station)
        {
            return _service.Create(station);
        }

        // PUT api/station/5
        public void Put([FromBody]Station station)
        {
            _service.Update(station);
        }

        // DELETE api/station/5
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
