using System.Web.Http;
using Newtonsoft.Json;
using Radiostr.Models;
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

        public MetricsResult Post(TrackImportModel model)
        {
            MetricsResult result;

            using (result = new MetricsResult(_metrics, "Radiostr.Web.Controllers.Post"))
            {
                result.Data = _trackImportService.ImportTracks(model);
            }

            return result;
        }
    }
}
