using materTestCore2.Models.EGovModels.health;
using System.Collections.ObjectModel;

namespace materTestCore2.Models.EGovInterfaces
{
    public interface IPatient
    {
        bool is_soldier { get; set; }
        ObservableCollection<Patient_injuries>? patient_has { get; set; }
    }
}
