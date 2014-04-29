using System.Collections.Generic;

namespace Radiostr.Repositories
{
    interface IRepository
    {
        IEnumerable<dynamic> Query(string sql, object param);
    }

    internal interface IRepository<T> : IRepository
    {
        int Create(T entity);
        T Get(int id);
        IEnumerable<T> GetList(string sql, object param);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> Query<TEntity>(string sql, object param);
    }
}