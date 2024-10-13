using materTestCore2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using materTestCore2.Security;
using materTestCore2.Repos.education;
using materTestCore2.Models.EGovModels;
using materTestCore2.Models.EGovModels.education;

namespace materTestCore2.Controllers.educationControllers
{
    public class CoursesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public CoursesController( IConfiguration configuration, graphContext graphContext)
        {
            _configuration = configuration;
            _graphContext = graphContext;
        }
        // GET: CoursesController
        [CustomAuthorize]
        public ActionResult Index()
        {
            //List<course> courses1 = _graphContext.CourseRepository.List().ToList();
            List<course> courses = _graphContext.courses;
            return View(courses);
        }


        // GET: CoursesController/Details/5
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            //List<course> courses1 = _graphContext.CourseRepository.List().ToList();

            List<course> courses = _graphContext.courses;
            course course = courses.First(a => a.GetHashCode() == id);
            List<exam> exams = course.has_exam.ToList();
            //return View(_graphContext.StudentProfiles.First(a => a.national_id == id.ToString()));
            return View(exams);
            //return View();
        }

        // GET: CoursesController/Create
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoursesController/Create
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

        // GET: CoursesController/Edit/5
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CoursesController/Edit/5
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

        // GET: CoursesController/Delete/5
        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CoursesController/Delete/5
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
