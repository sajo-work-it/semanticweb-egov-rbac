using materTestCore2.Helpers;
using materTestCore2.Models.EGovModels;
using materTestCore2.Models.EGovModels.education;
using materTestCore2.Models.EGovModels.health;
using materTestCore2.Models.EGovModels.personal;
using materTestCore2.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;
using VDS.RDF.Query;

namespace materTestCore2.Controllers.healthControllers
{
    public class PatientsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public PatientsController(IConfiguration configuration, graphContext graphContext)
        {

            _configuration = configuration;
            _graphContext = graphContext;
        }
        [CustomAuthorize]
        public ActionResult Index()
        {
            List<Patient> patients = _graphContext.patients;
            Patient p = _graphContext.PatientRepository.FindByUri(new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/data#person_12345"));
            return View(patients);
        }

        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            _graphContext.updateNamedGraph("health");
            //Functions.RestartFuseki("fuseki-server --update --mem /ds");
            string fusekiServerPath = "C:\\apache-jena-fuseki-4.6.1";
            //Functions.RestartFuseki(fusekiServerPath);
            Functions.RestartFuseki2(fusekiServerPath);
            List<ExpandoObject> model = new List<ExpandoObject>();
            Patient patient = _graphContext.patients.First(a => a.national_id == id);
            if (patient.patient_has !=null && patient.patient_has.Count >0)
            {
                foreach (Patient_injuries patient_Injury in patient.patient_has)
                {
                    Injury injury = patient_Injury.patient_injuries_injury;
                    //Injury injury = _graphContext.injuries.Where(a => a.injury_has.Any(b => b.GetHashCode() == patient_Injury.GetHashCode()) == true).First();
                    Hospital hospital = patient_Injury.patient_injuries_hospital;
                    //Hospital hospital = _graphContext.hospitals.Where(a => a.hospital_has.Any(b => b.GetHashCode() == patient_Injury.GetHashCode()) == true).First();

                    dynamic x = new ExpandoObject();
                    x.patient = patient;
                    x.injury = injury;
                    x.hospital = hospital;
                    x.patient_Injury = patient_Injury;
                    model.Add(x);
                }
            }
            else
            {
                dynamic x = new ExpandoObject();
                x.patient = patient;
                x.injury = null;
                x.hospital = null;
                x.patient_Injury = null;
                model.Add(x);
            }


            return View(model);

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
            PersonProfile? person = _graphContext.personRepository.List().First(a => a.national_id == int.Parse(collection["national_id"]));
            Citizen? citizen = _graphContext.CitizenRepository.FindByUri(person.Uri);

            Patient? patient = _graphContext.PatientRepository.List().FirstOrDefault(a => a.national_id == int.Parse(collection["national_id"]));

            if (patient != null)
            {
                TempData["ErrorMsg"] = "هذا المريض لديه ملف شخصي";
                return RedirectToAction("Create");
            }
            else
            {
                patient = new Patient(person.Uri);
                patient.is_soldier = bool.Parse(collection["is_soldier"].ToString().Split(',')[0]);

                Functions.addPatient(citizen, patient);
            }
            return RedirectToAction("Index");

        }

        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            Patient? patient = _graphContext.patients.Find(a => a.national_id == id);
            patientViewModel.patient = patient;

            patientViewModel.hospitalsList = new List<SelectListItem>();
            foreach (var item in _graphContext.hospitals)
            {
                patientViewModel.hospitalsList.Add(new SelectListItem { Text = item.hospital_name, Value = item.Uri.AbsoluteUri });
            }

            patientViewModel.injuriesList = new List<SelectListItem>();
            foreach (var item in _graphContext.injuries)
            {
                patientViewModel.injuriesList.Add(new SelectListItem { Text = item.injury_name, Value = item.Uri.AbsoluteUri });
            }
            return View(patientViewModel);
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Hospital hospital = _graphContext.HospitalRepository.FindByUri(new Uri(collection["hospital.Uri"]));
                string hospitalId = hospital.Uri.Fragment.Substring(10).ToLower();

                Injury injury = _graphContext.InjuryRepository.FindByUri(new Uri(collection["injury.Uri"]));
                string injuryId = injury.Uri.Fragment.Substring(7);

                Patient patient = _graphContext.PatientRepository.FindByUri(new Uri(collection["patient.Uri"]));
                string patientId = patient.Uri.Fragment.Substring(8).ToLower();

                int injury_date = int.Parse(collection["patient_Injuries.injury_date"]);
                int injury_percentage = int.Parse(collection["patient_Injuries.injury_percentage"]);

                Patient_injuries patient_Injuries = new Patient_injuries(injury_date, injury_percentage, new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/data#p"+patientId+"_i"+injuryId+"_"+hospitalId));
                _graphContext.patient_InjuriesRepository.Add(patient_Injuries);
                patient.patient_has.Add(patient_Injuries);
                hospital.hospital_has.Add(patient_Injuries);
                injury.injury_has.Add(patient_Injuries);
                patient.Commit();
                hospital.Commit();
                injury.Commit();
                
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
            Patient? patient = _graphContext.patients.Find(a => a.national_id == id);
            return View(patient);
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Patient? patient = _graphContext.patients.Find(a => a.national_id == id);
            Citizen? citizen = _graphContext.CitizenRepository.FindByUri(patient.Uri);

            Functions.removePatient(citizen, patient);

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
