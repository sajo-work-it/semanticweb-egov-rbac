using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;
using System.Net;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace materTestCore2.Models.EGovModels.health
{
    [RdfClass(HEALTH.patient_injuries)]
    public class Patient_injuries : Resource
    {

        [Display(Name = "تاريخ الاصابة")]
        public int injury_date
        {
            get { return GetValue(_injury_date); }
            set { SetValue(_injury_date, value); }
        }
        private PropertyMapping<int> _injury_date = new PropertyMapping<int>("injury_date", HEALTH.injury_date, 0);

        [Display(Name = "نسبة الاصابة")]
        public int injury_percentage
        {
            get { return GetValue(_injury_percentage); }
            set { SetValue(_injury_percentage, value); }
        }
        private PropertyMapping<int> _injury_percentage = new PropertyMapping<int>("injury_percentage", HEALTH.injury_percentage, 0);

        [Display(Name = "المستشفى")]
        public Hospital patient_injuries_hospital
        {
            get { return GetValue(_patient_injuries_hospital); }
            set { SetValue(_patient_injuries_hospital, value); }
        }
        private PropertyMapping<Hospital> _patient_injuries_hospital = new PropertyMapping<Hospital>("patient_injuries_hospital", HEALTH.patient_injuries_hospital);

        [Display(Name = "نوع الاصابة")]
        public Injury patient_injuries_injury
        {
            get { return GetValue(_patient_injuries_injury); }
            set { SetValue(_patient_injuries_injury, value); }
        }
        private PropertyMapping<Injury> _patient_injuries_injury = new PropertyMapping<Injury>("patient_injuries_injury", HEALTH.patient_injuries_injury);

        [Display(Name = "المريض")]
        public Patient patient_injuries_patient
        {
            get { return GetValue(_patient_injuries_patient); }
            set { SetValue(_patient_injuries_patient, value); }
        }
        private PropertyMapping<Patient> _patient_injuries_patient = new PropertyMapping<Patient>("patient_injuries_patient", HEALTH.patient_injuries_patient);


        #region Constructors


        public Patient_injuries(int injury_date, int injury_percentage, Uri uri) : base(uri)
        {
            this.injury_date = injury_date;
            this.injury_percentage = injury_percentage;
            
        }
        public Patient_injuries(Uri uri) : base(uri) { }

        #endregion
    }
}


