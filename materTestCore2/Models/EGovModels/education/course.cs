using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace materTestCore2.Models.EGovModels.education
{
    [RdfClass(EDUCATION.course)]
    public class course : Resource
    {
        #region Members

        [Display(Name = "اسم المقرر")]
        public string? course_name
        {
            get { return GetValue(_course_name); }
            set { SetValue<string>(_course_name, value); }
        }
        private PropertyMapping<string> _course_name = new PropertyMapping<string>("course_name", EDUCATION.course_name, "");


        [Display(Name = "امتحانات المقرر")]
        public ObservableCollection<exam>? has_exam
        {
            get { return GetValue(_has_exam); }
            set { SetValue<ObservableCollection<exam>>(_has_exam, value); }
        }
        private PropertyMapping<ObservableCollection<exam>> _has_exam = new PropertyMapping<ObservableCollection<exam>>("has_exam", EDUCATION.has_exam);

        [Display(Name = "كلية المقرر")]
        public college? belongs_to
        {
            get { return GetValue(_belongs_to); }
            set { SetValue<college>(_belongs_to, value); }
        }
        private PropertyMapping<college> _belongs_to = new PropertyMapping<college>("belongs_to", EDUCATION.belongs_to);


        #endregion

        #region Constructors

        public course(Uri uri) : base(uri) { }

        public course(string course_name, Uri uri) : base(uri)
        {
            this.course_name = course_name;
            has_exam = new ObservableCollection<exam>();
        }


        #endregion
    }
}
