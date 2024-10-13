using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace materTestCore2.Models.EGovModels.education
{
    [RdfClass(EDUCATION.college)]
    public class college : Resource
    {
        #region Members

        [Display(Name = "اسم الكلية")]
        public string? college_name
        {
            get { return GetValue(_college_name); }
            set { SetValue<string>(_college_name, value); }
        }
        private PropertyMapping<string> _college_name = new PropertyMapping<string>("college_name", EDUCATION.college_name, "");

        [Display(Name = "من قبل")]
        public ObservableCollection<StudentProfile>? enrolled_by
        {
            get { return GetValue(_enrolled_by); }
            set { SetValue<ObservableCollection<StudentProfile>>(_enrolled_by, value); }
        }
        private PropertyMapping<ObservableCollection<StudentProfile>> _enrolled_by = new PropertyMapping<ObservableCollection<StudentProfile>>("enrolled_by", EDUCATION.enrolled_by);

        [Display(Name = "مقررات الكلية")]
        public ObservableCollection<course>? college_has_course
        {
            get { return GetValue(_college_has_course); }
            set { SetValue<ObservableCollection<course>>(_college_has_course, value); }
        }
        private PropertyMapping<ObservableCollection<course>> _college_has_course = new PropertyMapping<ObservableCollection<course>>("college_has_course", EDUCATION.college_has_course);

        #endregion

        #region Constructors

        public college(Uri uri) : base(uri) { }

        public college(string college_name, Uri uri) : base(uri)
        {
            this.college_name = college_name;
            enrolled_by = new ObservableCollection<StudentProfile>();
            college_has_course = new ObservableCollection<course>();
        }

        #endregion
    }
}
