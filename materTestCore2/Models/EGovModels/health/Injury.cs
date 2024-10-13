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
    [RdfClass(HEALTH.injury)]
    public class Injury : Resource
    {
        [Display(Name = "نوع الاصابة")]
        public string injury_name
        {
            get { return GetValue(_injury_name); }
            set { SetValue(_injury_name, value); }
        }
        private PropertyMapping<string> _injury_name = new PropertyMapping<string>("injury_name", HEALTH.injury_name, "");

        public ObservableCollection<Patient_injuries> injury_has
        {
            get { return GetValue(_injury_has); }
            set { SetValue(_injury_has, value); }
        }
        private PropertyMapping<ObservableCollection<Patient_injuries>> _injury_has = new PropertyMapping<ObservableCollection<Patient_injuries>>("injury_has", HEALTH.injury_has);

        //[RdfProperty(HEALTH.injury_has)]
        //public ObservableCollection<Patient_injuries>? injury_has { get; set; }


        #region Constructors

        public Injury(string injury_name, Uri uri) : base(uri)
        {
            this.injury_name = injury_name;
            injury_has = new ObservableCollection<Patient_injuries>();

        }

        public Injury(Uri uri) : base(uri) { }

        #endregion
    }
}


