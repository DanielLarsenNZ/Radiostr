﻿using System;
using System.Collections.Generic;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class RadiostrService<T> : IService<T> where T : class
    {
        internal RadiostrService(ISecurityHelper securityHelper, IRepository<T> repository) 
        {
            _securityHelper = securityHelper;
            Repository = repository;            
        }

        private readonly ISecurityHelper _securityHelper;
        internal readonly IRepository<T> Repository;

        public virtual int Create(T model)
        {
            if (model == null) throw new ArgumentNullException("model");
            _securityHelper.Authenticate();

            return Repository.Create(model);
        }

        public virtual T Get(int id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException("id");
            _securityHelper.Authenticate();

            return Repository.Get(id);
        }

        public virtual IEnumerable<T> GetList(dynamic param)
        {
            throw new NotSupportedException();
        }

        public virtual void Update(T model)
        {
            if (model == null) throw new ArgumentNullException("model");
            _securityHelper.Authenticate();

            Repository.Update(model);
        }

        public virtual void Delete(T model)
        {
            if (model == null) throw new ArgumentNullException("model");
            _securityHelper.Authenticate();

            Repository.Delete(model);
        }

        /// <summary>
        /// Public factory method, in lieu of IoC.
        /// </summary>
        public static RadiostrService<T> CreateService()
        {
            return new RadiostrService<T>(new MockSecurityHelper(), new RadiostrRepository<T>(new RadiostrDbConnection()));
        }
    }
}