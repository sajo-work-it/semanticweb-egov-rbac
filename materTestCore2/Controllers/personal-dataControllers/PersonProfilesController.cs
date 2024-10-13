using materTestCore2.Models.EGovModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using materTestCore2.Models.EGovModels.personal;
using materTestCore2.Helpers;
using materTestCore2.Security;
using materTestCore2.Repos.citizens;

namespace materTestCore2.Controllers.personal_dataControllers
{
    public class PersonProfilesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public PersonProfilesController( IConfiguration configuration, graphContext graphContext)
        {
            _configuration = configuration;
            _graphContext = graphContext;
        }
        [CustomAuthorize]
        public ActionResult Index()
        {
            List<PersonProfile> personProfiles = _graphContext.personProfiles;
            return View(personProfiles);
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
            List<PersonProfile> persons = _graphContext.personProfiles;
            if (persons.Where(a=>a.national_id == int.Parse(collection["national_id"])).Count()!=0)
            {
                TempData["ErrorMsg"] = "يوجد مواطن يحمل نفس الرقم الوطني المدخل";
                return RedirectToAction("Create");
            }
            //int personCount = persons.Count;
            Uri uri = new Uri(string.Format("http://www.semanticweb.org/administrator/ontologies/2022/10/data#person_{0}", int.Parse(collection["national_id"])));
            bool personGender = bool.Parse(collection["gender"].ToString().Split(',')[0]);
            //PersonProfile personProfile = new PersonProfile(int.Parse(collection["national_id"]), personGender, collection["address"], collection["full_name"], uri);
            PersonProfile personProfile = new PersonProfile(uri);
            Citizen citizen = new Citizen(uri);
            personProfile.gender = personGender;
            personProfile.national_id = int.Parse(collection["national_id"]);
            personProfile.address = collection["address"];
            personProfile.full_name = collection["full_name"];
            if (Functions.addPerson(citizen, personProfile))
            {
                _graphContext.CitizenRepository.Add(citizen);

                return RedirectToAction("Index");
            }

            else
            {
                TempData["ErrorMsg"] = "حصل خطأ ما";
                return RedirectToAction("Create");

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
            PersonProfile? personProfile = _graphContext.personProfiles.Find(a => a.national_id == id);
            return View(personProfile);
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            PersonProfile? personProfile = _graphContext.personProfiles.Find(a => a.national_id == id);
            //citizen? citizen = personProfile.person_has_citizen.First();

            _graphContext.personRepository.Remove(personProfile);
            //_graphContext.CitizenRepository.Remove(citizen);
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
        [HttpGet]
        public JsonResult getPersonByNationalId(int id)
        {
            PersonProfile? personProfile = _graphContext.personRepository.List().FirstOrDefault(a => a.national_id == id);
            object jsonData = null;
            if (personProfile != null)
            {
                jsonData = new
                {
                    national_id = personProfile.national_id,
                    gender = personProfile.gender,
                    genderDisplay = personProfile.gender.boolGender(),
                    address = personProfile.address,
                    full_name = personProfile.full_name
                };
            }



            return Json(jsonData);


        }

    }
}
