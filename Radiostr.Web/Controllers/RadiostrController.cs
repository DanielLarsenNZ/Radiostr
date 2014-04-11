using System;
using System.Collections.Generic;
using System.Web.Http;
using Radiostr.Services;


namespace Radiostr.Web.Controllers
{
    public abstract class RadiostrController<T> :ApiController where T:class 
    {
        private readonly IService<T> _service = Service<T>.CreateService();

        // GET api/t
        public virtual IEnumerable<T> Get()
        {
            throw new NotSupportedException();
        }

        // GET api/t/5
        public virtual T Get(int id)
        {
            return _service.Get(id);
        }

        // POST api/t
        public virtual int Post([FromBody]T model)
        {
            return _service.Create(model);
        }

        // PUT api/t/5
        public virtual void Put([FromBody]T model)
        {
            _service.Update(model);
        }

        // DELETE api/t/5
        public virtual void Delete(int id)
        {
            _service.Delete(id);
        }
         
    }
}