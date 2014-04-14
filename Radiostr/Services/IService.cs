using System.Collections.Generic;

namespace Radiostr.Services
{
    public interface IService<T> where T : class
    {
        int Create(T model);
        T Get(int id);
        IEnumerable<T> GetList(dynamic param);
        void Update(T model);
        void Delete(T model);
    }
}