﻿using Radiostr.Model;
using Radiostr.Services;

namespace Radiostr.Web.Controllers
{
    public class StationController : RadiostrController<Station>
    {
        public StationController() : base(RadiostrService<Station>.CreateService())
        {
        }
    }
}
