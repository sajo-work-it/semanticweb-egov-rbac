using materTestCore2.Models;
using materTestCore2.Models.EGovModels;
using materTestCore2.Models.EGovModels.education;
using materTestCore2.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace materTestCore2.Controllers.educationControllers
{
    public class ExamsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public ExamsController( IConfiguration configuration, graphContext graphContext)
        {
            _configuration = configuration;
            _graphContext = graphContext;
        }
        // GET: ExamsController
        [CustomAuthorize]
        public ActionResult Index()
        {
            //List<exam> exams1 = _graphContext.ExamRepository.List().ToList();

            List<exam> exams = _graphContext.exams;
            return View(exams);
        }

        // GET: ExamsController/Details/5
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExamsController/Create
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamsController/Create
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

        // GET: ExamsController/Edit/5
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExamsController/Edit/5
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

        // GET: ExamsController/Delete/5
        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExamsController/Delete/5
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
