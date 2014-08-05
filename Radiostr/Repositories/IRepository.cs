using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiostr.Repositories
{
    interface IRepository
    {
        /// <summary>
        /// Executes a SQL command and params aginst a DB connection. Returns the result as IEnumerable{dynamic}.
        /// </summary>
        Task<IEnumerable<dynamic>> Query(string sql, object param);

        /// <summary>
        /// Executes a SQL command and params aginst a DB connection. Returns the result as IEnumerable{T}.
        /// </summary>
        Task<IEnumerable<T>> Query<T>(string sql, object param);

        /// <summary>
        /// Executes a SQL command and params aginst a DB connection. Returns the number of rows affected.
        /// </summary>
        Task<int> Execute(string sql, object param);
    }

    internal interface IRepository<T> : IRepository
    {
        int Create(T entity);
        T Get(int id);
        Task<IEnumerable<T>> GetList(string sql, object param);
        void Update(T entity);
        void Delete(T entity);
    }
}