using materTestCore2.Models.EGovModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using materTestCore2.Models.EGovModels.military;
using System.Dynamic;
using materTestCore2.Models.EGovModels.personal;
using Microsoft.AspNetCore.Mvc.Rendering;
using materTestCore2.Helpers;
using materTestCore2.Repos.health;
using VDS.RDF.Query;
using materTestCore2.Security;
using materTestCore2.Models.EGovModels.health;
using materTestCore2.Models.EGovModels.education;

namespace materTestCore2.Controllers.militaryControllers
{
    public class OfficersController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly graphContext _graphContext;

        public OfficersController( IConfiguration configuration, graphContext graphContext)
        {
            _configuration = configuration;
            _graphContext = graphContext;
        }

        [CustomAuthorize]
        public ActionResult Index()
        {
            List<Officer> officers = _graphContext.officers;
            return View(officers);
        }

        [CustomAuthorize]
        public ActionResult healthCondition()
        {
            List<ExpandoObject> model = new List<ExpandoObject>();

            List<Patient_injuries> patient_Injuries = _graphContext.patient_injuries;
            foreach (var patient_Injury in patient_Injuries)
            {
                Patient? patient = _graphContext.patients.FirstOrDefault(a => a.patient_has.Contains(patient_Injury));
                //PersonProfile? personProfile = _graphContext.personProfiles.FirstOrDefault(a => a.national_id == patient.national_id);
                Officer? officer = _graphContext.officers.FirstOrDefault(a => a.national_id == patient.national_id);
                if (officer == null)
                {
                    continue;
                }
                Injury injury = _graphContext.injuries.Where(a => a.injury_has.Any(b => b.GetHashCode() == patient_Injury.GetHashCode()) == true).First();
                Hospital hospital = _graphContext.hospitals.Where(a => a.hospital_has.Any(b => b.GetHashCode() == patient_Injury.GetHashCode()) == true).First();

                dynamic x = new ExpandoObject();
                x.officer = officer;
                x.injury = injury;
                x.hospital = hospital;
                x.patient_Injury = patient_Injury;
                model.Add(x);
            }


            return View(model);
        }

        [CustomAuthorize]
        public ActionResult healthConditionFiltered(IFormCollection collection)
        {
            List<ExpandoObject> model = new List<ExpandoObject>();

            object results = _graphContext.Store.ExecuteQuery(Queries2.prefix + Queries2.officersInjuryQuery + collection["percentage"] + ")");

            if (results is SparqlResultSet)
            {
                SparqlResultSet rset = (SparqlResultSet)results;

                foreach (SparqlResult r in rset)
                {
                    Officer officer1 = _graphContext.officers.Where(a => a.Uri == new Uri(Functions.getNodeValue(r, "officer").stringValue)).First();

                    Officer officer = _graphContext.OfficerRepository.FindByUri(new Uri(Functions.getNodeValue(r, "officer").stringValue));
                    dynamic x = new ExpandoObject();
                    x.officer = officer1;
                    x.sumPercent = Functions.getNodeValue(r, "per").intValue;
                    model.Add(x);
                }

            }
            else
            {
                throw new Exception("Did not get a SPARQL Result Set as expected");
            }

            return View(model);

        }


        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            _graphContext.updateNamedGraph("military");

            string fusekiServerPath = "C:\\apache-jena-fuseki-4.6.1";
            //Functions.RestartFuseki(fusekiServerPath);
            Functions.RestartFuseki2(fusekiServerPath);
            //_graphContext.updateNamedGraph("military");

            List<ExpandoObject> model = new List<ExpandoObject>();
            Officer officer = _graphContext.officers.First(a => a.national_id == id);
            if (officer.officer_has_jop != null && officer.officer_has_jop.Count != 0)
            {
                foreach (Jop jop in officer.officer_has_jop)
                {
                    Unit unit = jop.jop_has_unit;
                    //Unit unit = _graphContext.units.Where(a => a.unit_has_jop.Any(b => b.GetHashCode() == jop.GetHashCode()) == true).First();
                    Position position = jop.jop_has_position;
                    //Position position = _graphContext.positions.Where(a => a.position_has_jop.Any(b => b.GetHashCode() == jop.GetHashCode()) == true).First();
                    dynamic x = new ExpandoObject();
                    x.officer = officer;
                    x.unit = unit;
                    x.position = position;
                    x.jop = jop;

                    model.Add(x);
                }
            }
            else
            {
                dynamic x = new ExpandoObject();

                x.officer = officer;
                x.unit = null;
                x.position = null;
                x.jop = null;
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

            Officer? officer = _graphContext.OfficerRepository.List().FirstOrDefault(a => a.national_id == int.Parse(collection["national_id"]));

            if (officer != null)
            {
                TempData["ErrorMsg"] = "هذا الضابط مدخل سابقاً";
                return RedirectToAction("Create");
            }
            else
            {
                officer = new Officer(person.Uri);
                officer.Officer_rank = collection["Officer_rank"];
                officer.officer_specialization = collection["officer_specialization"];

                Functions.addOfficer(citizen, officer);
            }
            return RedirectToAction("Index");

        }

        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            OfficerViewModel officerViewModel = new OfficerViewModel();
            Officer? officer = _graphContext.officers.Find(a => a.national_id == id);
            officerViewModel.officer = officer;
            officerViewModel.unitsList = new List<SelectListItem>();
            foreach (var item in _graphContext.units)
            {
                officerViewModel.unitsList.Add(new SelectListItem { Text = item.unit_name, Value = item.Uri.AbsoluteUri });
            }            
            officerViewModel.positionsList = new List<SelectListItem>();
            foreach (var item in _graphContext.positions)
            {
                officerViewModel.positionsList.Add(new SelectListItem { Text = item.position_name, Value = item.Uri.AbsoluteUri });
            }
            return View(officerViewModel);
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Position position = _graphContext.PositionRepository.FindByUri(new Uri(collection["position.Uri"]));
                
                Unit unit = _graphContext.UnitRepository.FindByUri(new Uri(collection["unit.Uri"]));
                
                Officer officer = _graphContext.OfficerRepository.FindByUri(new Uri(collection["officer.Uri"]));

                Jop lastJop = officer.officer_has_jop.First();
                string lastJopId = lastJop.Uri.Fragment.Substring(1);
                string newJopId = lastJop.Uri.Fragment.Last().ToString();
                
                int year = DateTime.Now.Year;
                
                Jop jop = new Jop(year, new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/data#" + lastJopId + newJopId));
                _graphContext.JopRepository.Add(jop);
                officer.officer_has_jop.Add(jop);
                position.position_has_jop.Add(jop);
                unit.unit_has_jop.Add(jop);
                jop.Commit();
                officer.Commit();
                position.Commit();
                unit.Commit();
                //_graphContext.updateNamedGraph();
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
            Officer? officer = _graphContext.officers.Find(a => a.national_id == id);
            return View(officer);
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Officer? officer = _graphContext.officers.Find(a => a.national_id == id);
            Citizen? citizen = _graphContext.CitizenRepository.FindByUri(officer.Uri);

            Functions.removeOfficer(citizen, officer);
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
