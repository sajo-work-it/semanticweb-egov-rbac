using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;
using System.Net;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace materTestCore2.Models.EGovModels.military
{
    [RdfClass(MILITARY.unit)]
    public class Unit : Resource
    {

        [Display(Name = "اسم الوحدة")]
        public string unit_name
        {
            get { return GetValue(_unit_name); }
            set { SetValue(_unit_name, value); }
        }
        private PropertyMapping<string> _unit_name = new PropertyMapping<string>("unit_name", MILITARY.unit_name, "");

        [Display(Name = "مناطق الانتشار")]
        public string unit_positioning_place
        {
            get { return GetValue(_unit_positioning_place); }
            set { SetValue(_unit_positioning_place, value); }
        }
        private PropertyMapping<string> _unit_positioning_place = new PropertyMapping<string>("unit_positioning_place", MILITARY.unit_positioning_place, "");


        [Display(Name = "وظائف الوحدة")]
        public ObservableCollection<Jop> unit_has_jop
        {
            get { return GetValue(_unit_has_jop); }
            set { SetValue(_unit_has_jop, value); }
        }
        private PropertyMapping<ObservableCollection<Jop>> _unit_has_jop = new PropertyMapping<ObservableCollection<Jop>>("unit_has_jop", MILITARY.unit_has_jop);

        //[RdfProperty(MILITARY.unit_has_jop)]
        //public ObservableCollection<Jop>? unit_has_jop { get; set; }

        #region Constructors

        public Unit(string unit_name, string unit_positioning_place, Uri uri) : base(uri)
        {
            this.unit_name = unit_name;
            this.unit_positioning_place = unit_positioning_place;
            unit_has_jop = new ObservableCollection<Jop>();
        }
        public Unit(Uri uri) : base(uri) { }

        #endregion
    }
}


