using System;
using Radiostr.Entities;
using Radiostr.Models;
using Radiostr.Services;
using Radiostr.Web.Metrics;

namespace Radiostr.Web.Controllers
{
    public class TrackController : RadiostrController<Track>
    {
        private readonly ITrackImportService _trackImportService;
        private readonly MetricsRegistry _metrics;

        public TrackController()
            : base(RadiostrService<Track>.CreateService())
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

        public override int Post(Track model)
        {
            throw new NotSupportedException("See Post(TrackImportModel).");
        }

        public override void Put(Track model)
        {
            throw new NotSupportedException("Tracks are immutable.");
        }

        public override void Delete(Track model)
        {
            throw new NotImplementedException();
        }

        public override Track Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
