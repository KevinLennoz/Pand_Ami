using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pand_Ami.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pand_Ami.Controllers
{
    public class ExemplePrivaciController : Controller
    {
        private readonly ILogger<ExemplePrivaciController> _logger;

        public ExemplePrivaciController(ILogger<ExemplePrivaciController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privaci()
        {
            return View("viewTOTO");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
