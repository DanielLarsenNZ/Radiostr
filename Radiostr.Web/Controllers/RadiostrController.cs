using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Radiostr.Services;
using Radiostr.Web.Metrics;

namespace Radiostr.Web.Controllers
{
    /// <summary>
    /// Base controller that all Radiostr API controllers should inherit from.
    /// </summary>
    public abstract class RadiostrController : ApiController
    {
        /// <summary>
        /// Metrics Reigistry for creating, registering and getting lightweight metrics-style counters and guages.
        /// </summary>
        protected readonly MetricsRegistry Metrics;

        protected RadiostrController()
        {
            Metrics = new MetricsRegistry();
        }
    }

    /// <summary>
    /// A generic API controller of type <see cref="T"/> for simple Radiostr CRUD APIs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RadiostrController<T> : RadiostrController where T : class 
    {
        protected RadiostrController(RadiostrService<T> service)
        {
            Service = service;
        }

        protected IService<T> Service { get; set; }

        // GET api/t/5
        public virtual T Get(int id)
        {
            return Service.Get(id);
        }

        // GET api/t
        public async virtual Task<IEnumerable<T>> Get(dynamic param)
        {
            return await Service.GetList(param);
        }

        // POST api/t
        public virtual int Post([FromBody]T model)
        {
            return Service.Create(model);
        }

        // PUT api/t/5
        public virtual void Put([FromBody]T model)
        {
            Service.Update(model);
        }

        // DELETE api/t/5
        public virtual void Delete(T model)
        {
            Service.Delete(model);
        }
         
    }
}