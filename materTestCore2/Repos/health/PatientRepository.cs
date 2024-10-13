
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.health;

namespace materTestCore2.Repos.health
{
    public class PatientRepository : ResourceRepository<Patient>
    {
        public PatientRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public PatientRepository(Uri uri)
            : base(uri)
        {
        }
    }
}
