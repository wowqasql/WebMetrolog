using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMetrolog.Entity;
using WebMetrolog.Models;

namespace WebMetrolog.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ILogger<ReportsController> _logger;

        public ReportsController(ILogger<ReportsController> logger)
        {
            _logger = logger;
        }


        private readonly RootJson _rootJson;

        public ReportsController(RootJson rootJson)
        {
            _rootJson = rootJson;

        }

        [HttpGet]
        public ViewResult Ver()
        {
            Dictionary<string, List<Verification>> Verefication = JsonConvert.DeserializeObject<Dictionary<string, List<Verification>>>(_rootJson.ver);
           
            return View(Verefication);
        }

        [HttpGet]
        public ViewResult Cal()
        {
            Dictionary<string, List<Calibration>> Calibration = JsonConvert.DeserializeObject<Dictionary<string, List<Calibration>>>(_rootJson.cal);

            return View(Calibration);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
