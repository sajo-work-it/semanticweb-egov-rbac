
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.military;

namespace materTestCore2.Repos.military
{
    public class PositionRepository : ResourceRepository<Position>
    {
        public PositionRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public PositionRepository(Uri uri)
            : base(uri)
        {
        }
    }
}