using Radiostr.Model;

namespace Radiostr.Services
{
    public interface IStationService
    {
        int Create(Station station);
        Station Get(int id);
        void Update(Station station);
        void Delete(int id);
    }
}
