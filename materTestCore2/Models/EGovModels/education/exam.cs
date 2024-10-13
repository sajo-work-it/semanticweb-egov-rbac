using Semiodesk.Trinity;
using System;
using System.Collections.ObjectModel;
using OntologiesNamespace;
using System.ComponentModel.DataAnnotations;

namespace materTestCore2.Models.EGovModels.education
{
    [RdfClass(EDUCATION.exam)]
    public class exam : Resource
    {
        #region Members

        [Display(Name = "درجة الامتحان")]
        public float exam_grade
        {
            get { return GetValue(_exam_grade); }
            set { SetValue<float>(_exam_grade, value); }
        }
        private PropertyMapping<float> _exam_grade = new PropertyMapping<float>("exam_grade", EDUCATION.exam_grade, 0);

        [Display(Name = "تجاوز")]
        public bool exam_pass
        {
            get { return GetValue(_exam_pass); }
            set { SetValue<bool>(_exam_pass, value); }
        }
        private PropertyMapping<bool> _exam_pass = new PropertyMapping<bool>("exam_pass", EDUCATION.exam_pass, false);

        [Display(Name = "من قبل")]
        public StudentProfile done_by
        {
            get { return GetValue(_done_by); }
            set { SetValue(_done_by, value); }
        }
        private PropertyMapping<StudentProfile> _done_by = new PropertyMapping<StudentProfile>("done_by", EDUCATION.done_by);

        [Display(Name = "مقرر الامتحان")]
        public course exam_has_course
        {
            get { return GetValue(_exam_has_course); }
            set { SetValue(_exam_has_course, value); }
        }
        private PropertyMapping<course> _exam_has_course = new PropertyMapping<course>("exam_has_course", EDUCATION.exam_has_course);

        #endregion

        #region Constructors

        public exam(Uri uri) : base(uri) { }

        public exam(float exam_grade, bool exam_pass, Uri uri) : base(uri)
        {
            this.exam_grade = exam_grade;
            this.exam_pass = exam_pass;
        }

        #endregion
    }
}
