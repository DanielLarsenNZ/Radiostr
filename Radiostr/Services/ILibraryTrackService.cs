using Radiostr.Entities;

namespace Radiostr.Services
{
    /// <summary>
    /// A service for importing Tracks into a Station's Library.
    /// </summary>
    public interface ILibraryTrackService : IService<LibraryTrack>
    {
        bool TrackExistsInLibrary(int trackId, int libraryId);
        LibraryTrack Get(int libraryId, int trackId);
    }
}