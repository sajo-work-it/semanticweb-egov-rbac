using materTestCore2.Models.EGovModels;
using Microsoft.AspNetCore.Mvc;
using Semiodesk.Trinity;
using Semiodesk.Trinity.Store.Fuseki;
using System.Diagnostics;
using VDS.RDF.Configuration;
using VDS.RDF.Storage;

namespace materTestCore2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, graphContext graphContext)
        {
            _logger = logger;
            _configuration = configuration;
            _graphContext = graphContext;
        }



        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;

        //}

        public IActionResult Index()
        {

            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}