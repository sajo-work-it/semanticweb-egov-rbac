
using Microsoft.AspNetCore.Mvc.Rendering;

using materTestCore2.Models.EGovModels.health;

namespace materTestCore2.Models.EGovModels
{
    public class PatientViewModel
    {
        public Patient? patient { get; set; }
        public Injury? injury { get; set; }
        public Hospital? hospital { get; set; }
        public Patient_injuries? patient_Injuries { get; set; }

        public List<SelectListItem>? hospitalsList { get; set; }
        public List<SelectListItem>? injuriesList { get; set; }

    }
}
