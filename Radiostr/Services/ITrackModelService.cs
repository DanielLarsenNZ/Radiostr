using System.Threading.Tasks;
using Radiostr.Model;

namespace Radiostr.Services
{
    public interface ITrackModelService
    {
        Task<TrackModel[]> GetTracks(int[] trackIds);
    }
}