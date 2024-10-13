using materTestCore2.Models.EGovModels;
using materTestCore2.Models.EGovModels.health;
using materTestCore2.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace materTestCore2.Controllers.healthControllers
{
    public class InjuriesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public InjuriesController(IConfiguration configuration, graphContext graphContext)
        {
            _configuration = configuration;
            _graphContext = graphContext;
        }
        [CustomAuthorize]
        public ActionResult Index()
        {
            List<Injury> injuries = _graphContext.injuries;
            return View(injuries);
        }

        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
