using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Radiostr.Model.Entities;
using Radiostr.Services;

namespace Radiostr.Web.Controllers
{
    public class TxController : Controller
    {
        // GET: Tx
        [Route("tx/{id}")]
        public async Task<ActionResult> Index(string id)
        {
            // Select a schedule
            var txService = TransmitterService.GetService();
            //TODO: Only call Start once.
            await txService.Start(id);

            // Return a Station Model
            var stationService = RadiostrService<Station>.CreateService();
            return View(stationService.Get(int.Parse(id)));
        }
    }
}