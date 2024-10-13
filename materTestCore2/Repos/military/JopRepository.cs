
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.military;

namespace materTestCore2.Repos.military
{
    public class JopRepository : ResourceRepository<Jop>
    {
        public JopRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public JopRepository(Uri uri)
            : base(uri)
        {
        }
    }
}