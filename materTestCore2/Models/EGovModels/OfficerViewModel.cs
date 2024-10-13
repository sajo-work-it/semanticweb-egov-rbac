
using Microsoft.AspNetCore.Mvc.Rendering;

using materTestCore2.Models.EGovModels.military;

namespace materTestCore2.Models.EGovModels
{
    public class OfficerViewModel
    {
        public Officer? officer { get; set; }
        public Unit? unit { get; set; }
        public Position? position { get; set; }
        public Jop? jop { get; set; }

        public List<SelectListItem>? unitsList { get; set; }
        public List<SelectListItem>? positionsList { get; set; }

    }
}
