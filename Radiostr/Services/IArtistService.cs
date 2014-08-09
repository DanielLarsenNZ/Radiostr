using System.Threading.Tasks;
using Radiostr.Model;
using Radiostr.Model.Entities;

namespace Radiostr.Services
{
    public interface IArtistService
    {
        Task<ArtistModel[]> GetList(int[] artistIds);
    }
}