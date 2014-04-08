using System.Collections.Generic;

namespace Radiostr.Repositories
{
    interface IRepository<T>
    {
        int Create(T entity);
        T Get(int id);
        IEnumerable<T> GetList(string sql);
        void Update(T entity);
        void Delete(int id);
    }
}