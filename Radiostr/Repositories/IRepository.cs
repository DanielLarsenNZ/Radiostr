using System.Collections.Generic;

namespace Radiostr.Repositories
{
    interface IRepository<T>
    {
        int Create(T entity);
        T Get(int id);
        IEnumerable<T> GetList(string sql, object param);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<dynamic> Query(string sql, object param);
    }
}