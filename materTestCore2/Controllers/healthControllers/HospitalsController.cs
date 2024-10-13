using materTestCore2.Models;
using materTestCore2.Models.EGovModels;
using materTestCore2.Models.EGovModels.health;
using materTestCore2.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace materTestCore2.Controllers.healthControllers
{
    public class HospitalsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public HospitalsController( IConfiguration configuration, graphContext graphContext)
        {
            _configuration = configuration;
            _graphContext = graphContext;
        }
        // GET: HospitalsController
        [CustomAuthorize]
        public ActionResult Index()
        {
            List<Hospital> hospitals = _graphContext.hospitals;
            return View(hospitals);
        }

        // GET: HospitalsController/Details/5
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HospitalsController/Create
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HospitalsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize]
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

        // GET: HospitalsController/Edit/5
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HospitalsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize]
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

        // GET: HospitalsController/Delete/5
        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HospitalsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize]
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
