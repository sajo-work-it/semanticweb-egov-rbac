
using Microsoft.AspNetCore.Mvc.Rendering;
using materTestCore2.Models.EGovModels.education;

namespace materTestCore2.Models.EGovModels
{
    public class StudentViewModel
    {
        public StudentProfile? StudentProfile { get; set; }
        public course? course { get; set; }
        public exam? exam { get; set; }
        public List<SelectListItem>? coursesList { get; set; }
    }
}
