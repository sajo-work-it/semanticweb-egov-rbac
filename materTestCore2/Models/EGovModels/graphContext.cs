
using materTestCore2.Models.EGovModels.education;
using VDS.RDF.Query;
using Semiodesk.Trinity.Store.Fuseki;
using Semiodesk.Trinity;
using materTestCore2.Helpers;
using materTestCore2.Repos;
using materTestCore2.Repos.citizens;
using materTestCore2.Repos.education;
using materTestCore2.Repos.health;
using materTestCore2.Repos.military;
using materTestCore2.Repos.personal;
using materTestCore2.Models.EGovModels.health;
using System.Dynamic;
using AngleSharp.Html;
using materTestCore2.Models.EGovModels.military;
using materTestCore2.Models.EGovModels.personal;
using materTestCore2.Models.EGovModels;
using VDS.RDF.Storage;
using VDS.RDF;

namespace materTestCore2.Models.EGovModels
{
    public partial class graphContext
    {
        public FusekiStore? Store;

        public IModel defaultModel;
        public CollegeRepository CollegeRepository; public CourseRepository CourseRepository; public ExamRepository ExamRepository; public StudentProfileRepository StudentProfileRepository;
        public HospitalRepository HospitalRepository; public InjuryRepository InjuryRepository; public PatientRepository PatientRepository; public Patient_injuriesRepository patient_InjuriesRepository;
        public JopRepository JopRepository; public OfficerRepository OfficerRepository; public PositionRepository PositionRepository; public UnitRepository UnitRepository;
        public PersonRepository personRepository; public CitizenRepository CitizenRepository;
        public graphContext()
        {
            Store = (FusekiStore?)MyStoreFactory.GetStore();
            defaultModel = MyStoreFactory.GetModel(Store, new Uri("http://www.semanticweb.org/administrator/ontologies/2022/10/myModel"));


            //SparqlRemoteEndpoint sparqlRemoteEndpoint = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/EGOVDS/"));
            //var x = sparqlRemoteEndpoint.DefaultGraphs;
            //FusekiConnector fuseki = new FusekiConnector("http://localhost:3030/EGOVDS/data");
            
            ////Create a Graph and then load it with data from the store
            //Graph g = new Graph();
            //fuseki.LoadGraph(g, "");

            CitizenRepository = new CitizenRepository(defaultModel.Uri);
            personRepository = new PersonRepository(defaultModel.Uri);
            StudentProfileRepository = new StudentProfileRepository(defaultModel.Uri);
            ExamRepository = new ExamRepository(defaultModel.Uri);
            CollegeRepository = new CollegeRepository(defaultModel.Uri);
            CourseRepository = new CourseRepository(defaultModel.Uri);
            PatientRepository = new PatientRepository(defaultModel.Uri);
            HospitalRepository = new HospitalRepository(defaultModel.Uri);
            InjuryRepository = new InjuryRepository(defaultModel.Uri);
            patient_InjuriesRepository = new Patient_injuriesRepository(defaultModel.Uri);
            OfficerRepository = new OfficerRepository(defaultModel.Uri);
            JopRepository = new JopRepository(defaultModel.Uri);
            PositionRepository = new PositionRepository(defaultModel.Uri);
            UnitRepository = new UnitRepository(defaultModel.Uri);
            //updateNamedGraph();

        }

        public void updateNamedGraph( string type)
        {
            switch (type)
            {
                case "military":
                    //Store.ExecuteNonQuery(new SparqlUpdate(Queries2.prefix + Queries2.updateNamedGraphMilitary));
                    ISparqlUpdate sparqlUpdate = new SparqlUpdate(Queries2.updateNamedGraphMilitary);
                    Store.ExecuteNonQuery(sparqlUpdate);
                    break;
                case "health":
                    sparqlUpdate = new SparqlUpdate(Queries2.updateNamedGraphHealth);
                    Store.ExecuteNonQuery(sparqlUpdate);
                    break;
                case "education":
                    sparqlUpdate = new SparqlUpdate(Queries2.updateNamedGraphEducation);
                    Store.ExecuteNonQuery(sparqlUpdate);
                    break;

            }
            //ISparqlUpdate sparqlUpdate = new SparqlUpdate(Queries2.prefix + Queries2.updateNamedGraphMilitary);
            //Store.ExecuteNonQuery(sparqlUpdate);
        }
        public List<Citizen> citizens
        {
            get
            {
                return CitizenRepository.List().ToList();
            }
            set { }
        }

        //////////////////////////////////////////
        public List<PersonProfile> personProfiles
        {
            get
            {
                return personRepository.List().ToList();
                
            }
            set { }
        }
        ////////////////////////////////////////////
        public List<StudentProfile> StudentProfiles
        {
            get
            {
                return StudentProfileRepository.List().ToList();

            }
            set { }
        }
        public List<exam> exams
        {
            get
            {
                return ExamRepository.List().ToList();

            }
            set { }
        }
        public List<college> colleges
        {
            get
            {
                return CollegeRepository.List().ToList();

                
            }
            set { }
        }
        public List<course> courses
        {
            get
            {
                return CourseRepository.List().ToList();

                
            }
            set { }
        }
        ////////////////////////////////////////////
        public List<Patient> patients
        {
            get
            {

                return PatientRepository.List().ToList();

            }
            set { }
        }
        public List<Hospital> hospitals
        {
            get
            {
                return HospitalRepository.List().ToList();

            }
            set { }
        }
        public List<Injury> injuries
        {
            get
            {
                return InjuryRepository.List().ToList();

            }
            set { }
        }
        public List<Patient_injuries> patient_injuries
        {
            get
            {
                return patient_InjuriesRepository.List().ToList();

            }
            set { }
        }
        ////////////////////////////////////////////

        public List<Officer> officers
        {
            get
            {

                return OfficerRepository.List().ToList();

            }
            set { }
        }
        public List<Jop> jops
        {
            get
            {
                return JopRepository.List().ToList();

            }
            set { }
        }
        public List<Position> positions
        {
            get
            {
                return PositionRepository.List().ToList();

            }
            set { }
        }
        public List<Unit> units
        {
            get
            {
                return UnitRepository.List().ToList();

            }
            set { }
        }
        ////////////////////////////////////////////


    }
}
