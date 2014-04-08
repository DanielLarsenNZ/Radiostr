using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Radiostr.Web.Controllers
{
    public class StationController : ApiController
    {
        // GET api/station
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            throw new NotImplementedException();
        }

        // GET api/station/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/station
        public void Post([FromBody]string value)
        {
        }

        // PUT api/station/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/station/5
        public void Delete(int id)
        {
        }
    }
}
