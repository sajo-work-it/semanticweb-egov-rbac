
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.health;

namespace materTestCore2.Repos.health
{
    public class HospitalRepository : ResourceRepository<Hospital>
    {
        public HospitalRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public HospitalRepository(Uri uri)
            : base(uri)
        {
        }
    }
}
