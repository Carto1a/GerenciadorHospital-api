using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hospital.Controllers
{
    [Route("[controller]")]
    public class GenericAtendimentoController : Controller
    {
        private readonly ILogger<GenericAtendimentoController> _logger;

        public GenericAtendimentoController(ILogger<GenericAtendimentoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}