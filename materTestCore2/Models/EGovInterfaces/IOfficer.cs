using materTestCore2.Models.EGovModels.military;
using System.Collections.ObjectModel;

namespace materTestCore2.Models.EGovInterfaces
{
    public interface IOfficer
    {
        string Officer_rank { get; set; }
        string officer_specialization { get; set; }
        ObservableCollection<Jop>? officer_has_jop { get; set; }
    }
}
