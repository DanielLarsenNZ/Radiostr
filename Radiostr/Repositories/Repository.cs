using System.Collections.Generic;
using DapperExtensions;
using Radiostr.Data;

namespace Radiostr.Repositories
{
    internal class Repository<T> : IRepository<T> where T:class
    {
        internal Repository(IRadiostrDbConnection db)
        {
            _db = db;
        }

        private readonly IRadiostrDbConnection _db;

        public int Create(T entity)
        {
            int id;

            using (var conn = _db.GetDbConnection())
            {
                conn.Open();
                id = conn.Insert(entity);
                conn.Close();
            }

            return id;
        }

        public T Get(int id)
        {
            using (var conn = _db.GetDbConnection())
            {
                conn.Open();
                var entity = conn.Get<T>(id);
                conn.Close();
                return entity;
            }
        }

        public IEnumerable<T> GetList(string sql)
        {
            using (var conn = _db.GetDbConnection())
            {
                conn.Open();
                var entities = conn.Get<IEnumerable<T>>(sql);
                conn.Close();
                return entities;
            }
        }

        public void Update(T entity)
        {
            using (var conn = _db.GetDbConnection())
            {
                conn.Open();
                conn.Update(entity);
                conn.Close();
            }
        }

        public void Delete(int id)
        {
            using (var conn = _db.GetDbConnection())
            {
                conn.Open();
                conn.Delete<T>(id);
                conn.Close();
            }
        }
    }
}