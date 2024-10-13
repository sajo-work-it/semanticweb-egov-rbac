using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;

using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace materTestCore2.Models.EGovModels.personal
{
    [RdfClass(PERSONAL.PersonProfile)]
    public class PersonProfile: Resource
    {

        #region Members
        //[Display(Name = "الرقم الوطني")]

        //public int national_id
        //{
        //    get { return GetValue(this._national_id); }
        //    set { SetValue<int>(this._national_id, value); }
        //}
        //private PropertyMapping<int> _national_id = new PropertyMapping<int>("national_id", PERSONAL.national_id, 0);

        //[Display(Name = "الجنس")]

        //public bool gender
        //{
        //    get { return GetValue(this._gender); }
        //    set { SetValue<bool>(this._gender, value); }
        //}
        //private PropertyMapping<bool> _gender = new PropertyMapping<bool>("gender", PERSONAL.gender, false);

        //[Display(Name = "العنوان")]
        //public string address
        //{
        //    get { return GetValue(this._address); }
        //    set { SetValue<string>(this._address, value); }
        //}
        //private PropertyMapping<string> _address = new PropertyMapping<string>("address", PERSONAL.address, "");

        //[Display(Name = "الاسم الكامل")]
        //public string full_name
        //{
        //    get { return GetValue(this._full_name); }
        //    set { SetValue<string>(this._full_name, value); }
        //}
        //private PropertyMapping<string> _full_name = new PropertyMapping<string>("full_name", PERSONAL.full_name, "");

        [RdfProperty(PERSONAL.national_id)]
        public int national_id { get; set; }

        [RdfProperty(PERSONAL.gender)]
        public bool gender { get; set; }

        [RdfProperty(PERSONAL.address)]
        public string? address { get; set; }

        [RdfProperty(PERSONAL.full_name)]
        public string? full_name { get; set; }





        #endregion
        //public override IEnumerable<Class> GetTypes()
        //{
        //    yield return OntologiesNamespace.personal.PersonProfile;
        //}
        #region Constructors

        public PersonProfile(Uri uri) : base(uri) { }

        public PersonProfile(int national_id, bool gender, string address, string full_name, Uri uri) : base(uri)
        {
            this.national_id = national_id;
            this.gender = gender;
            this.address = address;
            this.full_name = full_name;
        }

        #endregion
    }
}
