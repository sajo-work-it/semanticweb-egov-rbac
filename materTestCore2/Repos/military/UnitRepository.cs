
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.military;

namespace materTestCore2.Repos.military
{
    public class UnitRepository : ResourceRepository<Unit>
    {
        public UnitRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public UnitRepository(Uri uri)
            : base(uri)
        {
        }
    }
}