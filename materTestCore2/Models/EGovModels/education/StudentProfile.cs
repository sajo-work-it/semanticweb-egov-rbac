using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;
using System.ComponentModel.DataAnnotations;
using materTestCore2.Models.EGovModels.personal;
using materTestCore2.Models.EGovInterfaces;

namespace materTestCore2.Models.EGovModels.education
{
    [RdfClass(EDUCATION.StudentProfile)]
    public class StudentProfile : PersonProfile /*, IStudentProfile*/
    {

        [Display(Name = "متخرج")]
        public bool student_graduated
        {
            get { return GetValue(_student_graduated); }
            set { SetValue(_student_graduated, value); }
        }
        private PropertyMapping<bool> _student_graduated = new PropertyMapping<bool>("student_graduated", EDUCATION.student_graduated, false);

        [Display(Name = "سنة الدراسة")]
        public int student_year
        {
            get { return GetValue(_student_year); }
            set { SetValue(_student_year, value); }
        }
        private PropertyMapping<int> _student_year = new PropertyMapping<int>("student_year", EDUCATION.student_year, 0);
        //رجعلا لهي المعلقة
        //[Display(Name = "كليات الطالب")]
        //public ObservableCollection<college>? enrolls_in
        //{
        //    get { return GetValue(_enrolls_in); }
        //    set { SetValue(_enrolls_in, value); }
        //}
        //private PropertyMapping<ObservableCollection<college>?> _enrolls_in = new PropertyMapping<ObservableCollection<college>?>("enrolls_in", EDUCATION.enrolls_in);

        [Display(Name = "امتحانات الطالب")]
        public ObservableCollection<exam>? Do
        {
            get { return GetValue(_do); }
            set { SetValue(_do, value); }
        }
        private PropertyMapping<ObservableCollection<exam>?> _do = new PropertyMapping<ObservableCollection<exam>?>("enrolls_in", EDUCATION._do);


        #region Constructors

        public StudentProfile(Uri uri) : base(uri) { }

        public StudentProfile(int national_id, bool gender, string address, string full_name, bool student_graduated, int student_year, Uri uri) : base(national_id, gender, address, full_name, uri)
        {
            this.student_graduated = student_graduated;
            this.student_year = student_year;
            Do = new ObservableCollection<exam>();
            //enrolls_in = new ObservableCollection<college>();
        }


        #endregion
    }
}
