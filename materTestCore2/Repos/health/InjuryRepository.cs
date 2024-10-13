
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.health;

namespace materTestCore2.Repos.health
{
    public class InjuryRepository : ResourceRepository<Injury>
    {
        public InjuryRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public InjuryRepository(Uri uri)
            : base(uri)
        {
        }
    }
}
