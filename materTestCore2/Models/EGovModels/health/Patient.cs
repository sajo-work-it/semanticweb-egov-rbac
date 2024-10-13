using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;
using System.Net;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using materTestCore2.Models.EGovModels.personal;
using materTestCore2.Models.EGovInterfaces;

namespace materTestCore2.Models.EGovModels.health
{
    [RdfClass(HEALTH.patient)]
    public class Patient : PersonProfile /*, IPatient*/
    {

        [Display(Name = "عسكري")]
        public bool is_soldier
        {
            get { return GetValue(_is_soldier); }
            set { SetValue(_is_soldier, value); }
        }
        private PropertyMapping<bool> _is_soldier = new PropertyMapping<bool>("is_soldier", HEALTH.is_soldier, false);

        [Display(Name = "عسكري")]
        public ObservableCollection<Patient_injuries> patient_has
        {
            get { return GetValue(_patient_has); }
            set { SetValue(_patient_has, value); }
        }
        private PropertyMapping<ObservableCollection<Patient_injuries>> _patient_has = new PropertyMapping<ObservableCollection<Patient_injuries>>("patient_has", HEALTH.patient_has);

        //[RdfProperty(HEALTH.patient_has)]
        //public ObservableCollection<Patient_injuries>? patient_has { get; set; }


        #region Constructors

        public Patient(Uri uri) : base(uri) { }
        public Patient(int national_id, bool gender, string address, string full_name, bool is_soldier, Uri uri) : base(national_id, gender, address, full_name, uri)
        {
            this.is_soldier = is_soldier;
            patient_has = new ObservableCollection<Patient_injuries>();
        }

        #endregion
    }
}

