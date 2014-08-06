using System.Threading.Tasks;
using Radiostr.Model.Entities;

namespace Radiostr.Services
{
    /// <summary>
    /// A service for importing Tracks into a Station's Library.
    /// </summary>
    public interface ILibraryTrackService : IService<LibraryTrack>
    {
        Task<bool> TrackExistsInLibrary(int trackId, int libraryId);
        Task<LibraryTrack> Get(int libraryId, int trackId);
    }
}