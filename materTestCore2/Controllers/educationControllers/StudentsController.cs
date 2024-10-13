using materTestCore2.Models.EGovModels.education;
using materTestCore2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using materTestCore2.Models.EGovModels.personal;
using AngleSharp.Dom;
using Microsoft.AspNetCore.Mvc.Rendering;
using materTestCore2.Security;
using materTestCore2.Models.EGovModels;
using materTestCore2.Models.EGovModels.military;
using Semiodesk.Trinity;
using VDS.RDF;
using OntologiesNamespace;
using materTestCore2.Helpers;

namespace materTestCore2.Controllers.educationControllers
{
    public class StudentsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public StudentsController( IConfiguration configuration, graphContext graphContext)
        {
            _configuration = configuration;
            _graphContext = graphContext;
        }
        // GET: StudentsController
        [CustomAuthorize]
        public ActionResult Index()
        {
            List<StudentProfile> studentProfiles1 = _graphContext.StudentProfiles;

            return View(studentProfiles1);
        }

        // GET: StudentsController/Details/5
        [CustomAuthorize]
        public ActionResult Details(/*int id ,*/ Uri uri)
        {
            _graphContext.updateNamedGraph("education");
            //Functions.RestartFuseki("fuseki-server --update --mem /ds");
            string fusekiServerPath = "C:\\apache-jena-fuseki-4.6.1";
            //Functions.RestartFuseki(fusekiServerPath);
            Functions.RestartFuseki2(fusekiServerPath);
            List<ExpandoObject> model = new List<ExpandoObject>();
            StudentProfile student = _graphContext.StudentProfileRepository.FindByUri(uri);
            if (student.Do != null && student.Do.Count != 0)
            {
                foreach (exam exam in student.Do)
                {
                    course c = exam.exam_has_course;
                    //course course = _graphContext.courses.First(a => a.has_exam.Contains(exam));
                    //course course2 = _graphContext.courses.Where(a => a.has_exam.Any(b => b.GetHashCode() == exam.GetHashCode()) == true).First();
                    dynamic x = new ExpandoObject();
                    x.student = student;
                    x.course = c;
                    x.exam = exam;
                    model.Add(x);
                }
            }
            else
            {
                dynamic x = new ExpandoObject();

                x.student = student;
                x.course = null;
                x.exam = null;
                model.Add(x);

            }


            return View(model);
        }

        // GET: StudentsController/Create
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            PersonProfile? person = _graphContext.personRepository.List().First(a => a.national_id == int.Parse(collection["national_id"]));
            Citizen? citizen = _graphContext.CitizenRepository.FindByUri(person.Uri);

            StudentProfile? student = _graphContext.StudentProfileRepository.List().FirstOrDefault(a => a.national_id == int.Parse(collection["national_id"]));

            if (student != null)
            {
                TempData["ErrorMsg"] = "هذا الطالب مدخل سابقاً";
                return RedirectToAction("Create");
            }
            else
            {
                student = new StudentProfile(person.Uri);
                student.student_year = int.Parse(collection["student_year"]);
                student.student_graduated = bool.Parse(collection["student_graduated"].ToString().Split(',')[0]);

                Functions.addStudent(citizen, student);
            }
            return RedirectToAction("Index");

        }

        // GET: StudentsController/Edit/5
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            //StudentProfile? studentProfile = _graphContext.StudentProfiles.Find(a => a.national_id == id);
            StudentProfile? studentProfile = _graphContext.StudentProfileRepository.List().First(a => a.national_id == id);

            studentViewModel.StudentProfile = studentProfile;
            studentViewModel.coursesList = new List<SelectListItem>();
            foreach (var item in _graphContext.CourseRepository.List())
            {
                studentViewModel.coursesList.Add(new SelectListItem {Text = item.course_name , Value = item.Uri.AbsoluteUri });
            }
            return View(studentViewModel);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                course course = _graphContext.CourseRepository.FindByUri(new Uri(collection["course.Uri"]));
                string coursId = course.Uri.Fragment.Substring(1);
                StudentProfile studentProfile = _graphContext.StudentProfileRepository.FindByUri(new Uri(collection["StudentProfile.Uri"]));
                string studentId = studentProfile.Uri.Fragment.Substring(1);
                float exam_grade = float.Parse(collection["exam.exam_grade"]);
                bool exam_pass = exam_grade > 59 ? true:false;
                int count = 1;
                foreach (var item in studentProfile.Do)
                {
                    foreach (var item2 in course.has_exam)
                    {
                        if (item.GetHashCode() == item2.GetHashCode())
                        {
                            count++;
                        }
                    }
                }
                exam exam = new exam(exam_grade, exam_pass, new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/data#"+"exam"+count+"_"+studentId+"_"+coursId));
                _graphContext.ExamRepository.Add(exam);
                studentProfile.Do.Add(exam);
                course.has_exam.Add(exam);
                exam.Commit();
                studentProfile.Commit();
                course.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            //StudentProfile? studentProfile = _graphContext.StudentProfiles.Find(a => a.national_id == id);
            StudentProfile? studentProfile = _graphContext.StudentProfileRepository.List().First(a => a.national_id == id);
            return View(studentProfile);
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            StudentProfile? student = _graphContext.StudentProfileRepository.List().First(a => a.national_id == id);
            Citizen? citizen = _graphContext.CitizenRepository.FindByUri(student.Uri);

            Functions.removeStudent(citizen, student);

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
