using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NaveedDotNetPoc.Models;

namespace NaveedDotNetPoc.Controllers
{
    
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("api/v0/myrestendpoint")]
        [HttpGet]
        public IActionResult GetApplicationConfigurationDetails()
        {
            var analyticsUrl = _configuration["AnalyticsUrl"];
            return Ok($"The Analytics Url is {analyticsUrl}");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
