using System;
using System.Threading.Tasks;
using Radiostr.Model.Entities;
using Radiostr.Services;
using Radiostr.Web.Metrics;

namespace Radiostr.Web.Controllers
{
    public class StationController : RadiostrController<Station>
    {
        public StationController() : base(RadiostrService<Station>.CreateService())
        {
        }

        public override int Post(Station model)
        {
            model.WhenCreated = DateTime.Now;
            return base.Post(model);
        }

        public async Task<MetricsResult> Post(bool createLibrary, Station station)
        {
            MetricsResult result;

            using (result = new MetricsResult(new MetricsRegistry(), "Radiostr.Web.Controllers.StationController.Post"))
            {
                if (createLibrary == false)
                {
                    result.Data = Post(station);
                }

                var service = StationService.GetService();
                var data = await service.CreateStationAndLibrary(station);
                result.Data = new {StationId = data.Item1, LibraryId = data.Item2};
            }

            return result;
        } 
    }
}
