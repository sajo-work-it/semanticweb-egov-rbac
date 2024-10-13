
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.health;

namespace materTestCore2.Repos.health
{
    public class Patient_injuriesRepository : ResourceRepository<Patient_injuries>
    {
        public Patient_injuriesRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public Patient_injuriesRepository(Uri uri)
            : base(uri)
        {
        }
    }
}
