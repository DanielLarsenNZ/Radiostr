using System;
using System.Collections.Generic;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class Service<T> : IService<T> where T : class
    {
        internal Service(ISecurityHelper securityHelper, IRepository<T> repository) 
        {
            _securityHelper = securityHelper;
            _repository = repository;            
        }

        private readonly ISecurityHelper _securityHelper;
        private readonly IRepository<T> _repository;

        public virtual int Create(T model)
        {
            if (model == null) throw new ArgumentNullException("model");
            _securityHelper.Authenticate();

            return _repository.Create(model);
        }

        public virtual T Get(int id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException("id");
            _securityHelper.Authenticate();

            return _repository.Get(id);
        }

        public virtual IEnumerable<T> GetList(string sql)
        {
            if (string.IsNullOrEmpty(sql)) throw new ArgumentOutOfRangeException("sql");
            _securityHelper.Authenticate();

            return _repository.GetList(sql);
        }

        public virtual void Update(T model)
        {
            if (model == null) throw new ArgumentNullException("model");
            _securityHelper.Authenticate();

            _repository.Update(model);
        }

        public virtual void Delete(int id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException("id");
            _securityHelper.Authenticate();

            _repository.Delete(id);
        }

        /// <summary>
        /// Public factory method, in lieu of IoC.
        /// </summary>
        public static Service<T> CreateService()
        {
            return new Service<T>(new MockSecurityHelper(), new Repository<T>(new RadiostrDbConnection()));
        }

    }
}