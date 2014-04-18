using System;
using System.Security.Cryptography.X509Certificates;
using Radiostr.Models;
using Radiostr.Services;

namespace Radiostr.Web.Controllers
{
    public class TrackController : RadiostrController<Track>
    {
        public TrackController() : base(RadiostrService<Track>.CreateService())
        {
        }

        public override int Post(Track model)
        {
            throw new NotSupportedException();
        }

        public void Post(dynamic model)
        {
            
        }

    }
}
