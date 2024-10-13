using materTestCore2.Models.EGovModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using materTestCore2.Models.EGovModels.military;
using materTestCore2.Security;

namespace materTestCore2.Controllers.militaryControllers
{
    public class JopsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public JopsController( IConfiguration configuration, graphContext graphContext)
        {
            _configuration = configuration;
            _graphContext = graphContext;
        }
        [CustomAuthorize]
        public ActionResult Index()
        {
            List<Jop> jops = _graphContext.jops;
            return View(jops);
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
