using System.Threading.Tasks;
using Radiostr.Model;

namespace Radiostr.Services
{
    /// <summary>
    /// Imports Tracks into a Library.
    /// </summary>
    public interface ITrackImportService
    {
        Task ImportTracks(TracksImportModel model);
    }
}