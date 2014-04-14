using Radiostr.Model;
using Radiostr.Services;

namespace Radiostr.Web.Controllers
{
    public class TrackController : RadiostrController<Track>
    {
        public TrackController() : base(RadiostrService<Track>.CreateService())
        {
        }

    }
}
