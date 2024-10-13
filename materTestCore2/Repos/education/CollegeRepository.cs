
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.education;

namespace materTestCore2.Repos.education
{
    public class CollegeRepository : ResourceRepository<college>
    {
        public CollegeRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public CollegeRepository(Uri uri)
            : base(uri)
        {
        }
    }
}