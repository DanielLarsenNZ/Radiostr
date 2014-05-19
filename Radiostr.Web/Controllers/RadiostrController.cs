﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Radiostr.Services;


namespace Radiostr.Web.Controllers
{
    public abstract class RadiostrController<T> : ApiController where T:class 
    {
        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }

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
        public virtual IEnumerable<T> Get(dynamic param)
        {
            return Service.GetList(param);
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