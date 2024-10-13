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
    [RdfClass(MILITARY.position)]
    public class Position : Resource
    {

        [Display(Name = "الوظيفة")]
        public string position_name
        {
            get { return GetValue(_position_name); }
            set { SetValue(_position_name, value); }
        }
        private PropertyMapping<string> _position_name = new PropertyMapping<string>("position_name", MILITARY.position_name, "");

        [Display(Name = "راتب الوظيفة")]
        public float position_salary
        {
            get { return GetValue(_position_salary); }
            set { SetValue<float>(_position_salary, value); }
        }
        private PropertyMapping<float> _position_salary = new PropertyMapping<float>("position_salary", MILITARY.position_salary, 0);


        [Display(Name = "تاريخ المسمى الوظيفي")]
        public ObservableCollection<Jop> position_has_jop
        {
            get { return GetValue(_position_has_jop); }
            set { SetValue(_position_has_jop, value); }
        }
        private PropertyMapping<ObservableCollection<Jop>> _position_has_jop = new PropertyMapping<ObservableCollection<Jop>>("position_has_jop", MILITARY.position_has_jop);

        //[RdfProperty(MILITARY.position_has_jop)]
        //public ObservableCollection<Jop>? position_has_jop { get; set; }

        #region Constructors

        public Position(string position_name, float position_salary, Uri uri) : base(uri)
        {
            this.position_name = position_name;
            this.position_salary = position_salary;
            position_has_jop = new ObservableCollection<Jop>();
        }
        public Position(Uri uri) : base(uri) { }

        #endregion
    }
}


