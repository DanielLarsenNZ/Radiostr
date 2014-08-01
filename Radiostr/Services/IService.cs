using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiostr.Services
{
    public interface IService<T> where T : class
    {
        int Create(T model);
        T Get(int id);
        Task<IEnumerable<T>> GetList(dynamic param);
        void Update(T model);
        void Delete(T model);
    }
}