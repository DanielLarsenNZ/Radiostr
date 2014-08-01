using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiostr.Repositories
{
    interface IRepository
    {
        Task<IEnumerable<dynamic>> Query(string sql, object param);
    }

    internal interface IRepository<T> : IRepository
    {
        int Create(T entity);
        T Get(int id);
        Task<IEnumerable<T>> GetList(string sql, object param);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> Query<TEntity>(string sql, object param);
    }
}