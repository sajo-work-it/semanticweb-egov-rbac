using materTestCore2.Models.EGovModels.education;
using System.Collections.ObjectModel;

namespace materTestCore2.Models.EGovInterfaces
{
    public interface IStudentProfile
    {
        bool student_graduated { get; set; }
        int student_year { get; set; }
        //ObservableCollection<college>? enrolls_in { get; set; }
        ObservableCollection<exam>? Do { get; set; }
    }
}
