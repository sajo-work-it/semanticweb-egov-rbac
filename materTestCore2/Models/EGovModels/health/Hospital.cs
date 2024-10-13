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
    [RdfClass(HEALTH.hospital)]
    public class Hospital : Resource
    {

        [Display(Name = "عنوان المستشفى")]
        public string hospital_address
        {
            get { return GetValue(_hospital_address); }
            set { SetValue(_hospital_address, value); }
        }
        private PropertyMapping<string> _hospital_address = new PropertyMapping<string>("hospital_address", HEALTH.hospital_address, "");

        [Display(Name = "اسم المستشفى")]
        public string hospital_name
        {
            get { return GetValue(_hospital_name); }
            set { SetValue(_hospital_name, value); }
        }
        private PropertyMapping<string> _hospital_name = new PropertyMapping<string>("hospital_name", HEALTH.hospital_name, "");

        [Display(Name = "حالات المستشفى")]
        public ObservableCollection<Patient_injuries>? hospital_has
        {
            get { return GetValue(_hospital_has); }
            set { SetValue(_hospital_has, value); }
        }
        private PropertyMapping<ObservableCollection<Patient_injuries>?> _hospital_has = new PropertyMapping<ObservableCollection<Patient_injuries>?>("hospital_has", HEALTH.hospital_has);

        //[RdfProperty(HEALTH.hospital_has)]
        //public ObservableCollection<Patient_injuries>? hospital_has { get; set; }


        #region Constructors

        public Hospital(string hospital_address, string hospital_name, Uri uri) : base(uri)
        {
            this.hospital_address = hospital_address;
            this.hospital_name = hospital_name;
            hospital_has = new ObservableCollection<Patient_injuries>();
        }
        public Hospital(Uri uri) : base(uri) { }


        #endregion
    }
}


