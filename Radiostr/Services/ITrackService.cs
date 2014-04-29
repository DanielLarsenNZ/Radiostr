using Radiostr.Entities;

namespace Radiostr.Services
{
    public interface ITrackService : IService<Track>
    {
        int CreateTrack(int artistId, int albumId, string track, string uri, float duration);

        int CreateTrack(int artistId, string album, string track, string uri, float duration);
    }
}