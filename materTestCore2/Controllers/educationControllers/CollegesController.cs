using materTestCore2.Models.EGovModels.education;
using materTestCore2.Models.EGovModels;
using materTestCore2.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace materTestCore2.Controllers.educationControllers
{
    public class CollegesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public CollegesController( IConfiguration configuration, graphContext graphContext)
        {
            _configuration = configuration;
            _graphContext = graphContext;
        }
        // GET: CollegesController
        [CustomAuthorize]
        public ActionResult Index()
        {
            //List<college> colleges1 = _graphContext.CollegeRepository.List().ToList();
            //college college = _graphContext.CollegeRepository.FindByUri(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/data#svu_ite"));
            List <college> colleges = _graphContext.colleges;
            return View(colleges);
        }

        // GET: CollegesController/Details/5
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CollegesController/Create
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CollegesController/Create
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

        // GET: CollegesController/Edit/5
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CollegesController/Edit/5
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

        // GET: CollegesController/Delete/5
        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CollegesController/Delete/5
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
