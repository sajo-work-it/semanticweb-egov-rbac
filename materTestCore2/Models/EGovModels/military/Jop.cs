using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;
using System.Net;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace materTestCore2.Models.EGovModels.military
{
    [RdfClass(MILITARY.jop)]
    public class Jop : Resource
    {

        [Display(Name = "سنة التعيين")]
        public int jop_year
        {
            get { return GetValue(_jop_year); }
            set { SetValue(_jop_year, value); }
        }
        private PropertyMapping<int> _jop_year = new PropertyMapping<int>("jop_year", MILITARY.jop_year, 0);


        [Display(Name = "المسمى الوظيفي")]
        public Position jop_has_position
        {
            get { return GetValue(_jop_has_position); }
            set { SetValue(_jop_has_position, value); }
        }
        private PropertyMapping<Position> _jop_has_position = new PropertyMapping<Position>("jop_has_position", MILITARY.jop_has_position);

        [Display(Name = "الضابط")]
        public Officer jop_has_officer
        {
            get { return GetValue(_jop_has_officer); }
            set { SetValue(_jop_has_officer, value); }
        }
        private PropertyMapping<Officer> _jop_has_officer = new PropertyMapping<Officer>("jop_has_officer", MILITARY.jop_has_officer);

        [Display(Name = "الوحدة")]
        public Unit jop_has_unit
        {
            get { return GetValue(_jop_has_unit); }
            set { SetValue(_jop_has_unit, value); }
        }
        private PropertyMapping<Unit> _jop_has_unit = new PropertyMapping<Unit>("jop_has_unit", MILITARY.jop_has_unit);



        #region Constructors
        public Jop(int jop_year, Uri uri) : base(uri)
        {
            this.jop_year = jop_year;
            
        }
        public Jop(Uri uri) : base(uri) { }

        #endregion
    }
}


