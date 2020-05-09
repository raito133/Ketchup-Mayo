using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KetchupMayoSite.Models;
using KetchupMayoSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace KetchupMayoSite.Controllers
{
    [Route("ketchup")]
    public class KetchupController : Controller
    {
        private IKetchupService _ketchupService;
        public KetchupController(IKetchupService ketchupService)
        {
            _ketchupService = ketchupService;
        }
        
        public IActionResult Index()
        {
            return View(_ketchupService.Get());
        }
    }
}