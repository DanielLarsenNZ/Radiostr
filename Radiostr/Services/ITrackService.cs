using Radiostr.Model.Entities;

namespace Radiostr.Services
{
    public interface ITrackService : IService<Track>
    {
        int CreateTrack(int artistId, int albumId, string track, string uri, int duration);
        
        int CreateTrack(int artistId, string track, string uri, int duration);
    }
}