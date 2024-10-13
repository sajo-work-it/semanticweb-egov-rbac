using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;
using System.Net;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using materTestCore2.Models.EGovModels.personal;
using materTestCore2.Models.EGovInterfaces;

namespace materTestCore2.Models.EGovModels.military
{
    [RdfClass(MILITARY.officer)]
    public class Officer : PersonProfile/* , IOfficer*/
    {

        //[Display(Name = "رتبة الضابط")]
        //public string Officer_rank
        //{
        //    get { return GetValue(this._officer_rank); }
        //    set { SetValue<string>(this._officer_rank, value); }
        //}
        //private PropertyMapping<string> _officer_rank = new PropertyMapping<string>("officer_rank", MILITARY.officer_rank, "");

        //[Display(Name = "اختصاص الضابط")]
        //public string officer_specialization
        //{
        //    get { return GetValue(this._officer_specialization); }
        //    set { SetValue<string>(this._officer_specialization, value); }
        //}
        //private PropertyMapping<string> _officer_specialization = new PropertyMapping<string>("officer_specialization", MILITARY.officer_specialization, "");



        //[Display(Name = "وظيفة الضابط")]
        //public ObservableCollection<Jop> officer_has_jop
        //{
        //    get { return GetValue(_officer_has_jop); }
        //    set { SetValue(_officer_has_jop, value); }
        //}
        //private PropertyMapping<ObservableCollection<Jop>> _officer_has_jop = new PropertyMapping<ObservableCollection<Jop>>("officer_has_jop", MILITARY.officer_has_jop);

        [RdfProperty(MILITARY.officer_rank)]
        public string Officer_rank { get; set; }

        [RdfProperty(MILITARY.officer_specialization)]
        public string officer_specialization { get; set; }


        [RdfProperty(MILITARY.officer_has_jop)]
        public ObservableCollection<Jop>? officer_has_jop { get; set; }



        #region Constructors

        public Officer(Uri uri) : base(uri) { }

        public Officer(int national_id, bool gender, string address, string full_name, string officer_rank, string officer_specialization, Uri uri) : base(national_id, gender, address, full_name, uri)
        {
            Officer_rank = officer_rank;
            this.officer_specialization = officer_specialization;
            officer_has_jop = new ObservableCollection<Jop>();
        }
        #endregion
    }
}

