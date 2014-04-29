using System.Collections.Generic;
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

        public IEnumerable<dynamic> Query(string sql, object param)
        {
            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                var result = conn.Query(sql, param);
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

        public IEnumerable<T> GetList(string sql, object param)
        {
            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                var entities = conn.Query<T>(sql, param);
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

        public IEnumerable<T> Query<TEntity>(string sql, object param)
        {
            using (var conn = Db.GetDbConnection())
            {
                conn.Open();
                var result = conn.Query<T>(sql, param);
                conn.Close();
                return result;
            }
        }
    }
}