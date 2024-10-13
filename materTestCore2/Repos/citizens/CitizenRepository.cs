
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels;

namespace materTestCore2.Repos.citizens
{
    public class CitizenRepository : ResourceRepository<Citizen>
    {
        public CitizenRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public CitizenRepository(Uri uri)
            : base(uri)
        {
        }
    }
}