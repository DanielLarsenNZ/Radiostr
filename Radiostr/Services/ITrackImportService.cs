using Radiostr.Models;

namespace Radiostr.Services
{
    /// <summary>
    /// Imports Tracks into a Library, returns a lists of messages.
    /// </summary>
    public interface ITrackImportService
    {
        string[] ImportTracks(TrackImportModel model);
    }
}