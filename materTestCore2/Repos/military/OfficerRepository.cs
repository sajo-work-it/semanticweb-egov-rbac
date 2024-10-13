
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.military;

namespace materTestCore2.Repos.military
{
    public class OfficerRepository : ResourceRepository<Officer>
    {
        public OfficerRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public OfficerRepository(Uri uri)
            : base(uri)
        {
        }
    }
}