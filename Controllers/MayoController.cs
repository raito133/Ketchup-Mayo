using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KetchupMayoSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace KetchupMayoSite.Controllers
{
    [Route("mayo")]
    public class MayoController : Controller
    {
        private IMayoService _mayoService;
        public MayoController(IMayoService mayoService)
        {
            _mayoService = mayoService;
        }
        public IActionResult Index()
        {
            return View(_mayoService.Get());
        }
    }
}