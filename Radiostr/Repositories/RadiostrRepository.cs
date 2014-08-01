﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using Radiostr.Data;

namespace Radiostr.Repositories
{
    internal class RadiostrRepository : IRepository
    {
        internal RadiostrRepository(IRadiostrDbConnection db)
        {
            Db = db;
        }

        public async Task<IEnumerable<dynamic>> Query(string sql, object param)
        {
            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                var result = await conn.QueryAsync<dynamic>(sql, param);
                conn.Close();
                return result;
            }
        }

        protected readonly IRadiostrDbConnection Db;
    }

    internal class RadiostrRepository<T> : RadiostrRepository, IRepository<T> where T:class
    {
        internal RadiostrRepository(IRadiostrDbConnection db) : base(db)
        {
        }

        public int Create(T entity)
        {
            int id;

            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                id = conn.Insert(entity);
                conn.Close();
            }

            return id;
        }

        public T Get(int id)
        {
            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                var entity = conn.Get<T>(id);
                conn.Close();
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetList(string sql, object param)
        {
            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                var entities = await conn.QueryAsync<T>(sql, param);
                conn.Close();
                return entities;
            }
        }

        public void Update(T entity)
        {
            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                conn.Update(entity);
                conn.Close();
            }
        }

        public void Delete(T entity)
        {
            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                conn.Delete(entity);
                conn.Close();
            }
        }

        public async Task<IEnumerable<T>> Query<TEntity>(string sql, object param)
        {
            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                var result = await conn.QueryAsync<T>(sql, param);
                conn.Close();
                return result;
            }
        }
    }
}