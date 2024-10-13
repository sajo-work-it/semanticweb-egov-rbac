using materTestCore2.Models.EGovInterfaces;
using materTestCore2.Models.EGovModels.personal;
using Semiodesk.Trinity;
using System;
using OntologiesNamespace;
using materTestCore2.Models.EGovModels.education;
using materTestCore2.Models.EGovModels.health;
using materTestCore2.Models.EGovModels.military;

namespace materTestCore2.Models.EGovModels
{
    [RdfClass(PERSONAL.Citizen)]
    public class Citizen : Resource
    {
        //[RdfProperty(PERSONAL.PersonProfile)]
        //public PersonProfile? PersonProfile { get; set; }

        //[RdfProperty(EDUCATION.StudentProfile)]
        //public StudentProfile? StudentProfile { get; set; }

        //[RdfProperty(HEALTH.patient)]
        //public Patient? Patient { get; set; }

        //[RdfProperty(MILITARY.officer)]
        //public Officer? Officer { get; set; }

        public Citizen(Uri uri) : base(uri) { }

        //public Citizen(Uri uri , PersonProfile personProfile, IStudentProfile? studentProfile = null, IPatient? patient = null, IOfficer? officer = null) : base(uri)
        //{
        //    PersonProfile = personProfile;
        //    StudentProfile = studentProfile;
        //    Patient = patient;
        //    Officer = officer;
        //}
    }
}
