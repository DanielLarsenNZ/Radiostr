using System.Threading.Tasks;
using System.Web.Http;
using Radiostr.Model;
using Radiostr.Services;
using Radiostr.Web.Metrics;

namespace Radiostr.Web.Controllers
{
    public class TrackController : ApiController
    {
        private readonly ITrackImportService _trackImportService;
        private readonly MetricsRegistry _metrics;

        public TrackController()
        {
            _trackImportService = TrackImportService.CreateTrackImportService();
            _metrics = new MetricsRegistry();
        }

        public async Task<MetricsResult> Post(TracksImportModel model)
        {
            MetricsResult result;

            using (result = new MetricsResult(_metrics, "Radiostr.Web.Controllers.Post"))
            {
                await _trackImportService.ImportTracks(model);
            }

            return result;
        }
    }
}
