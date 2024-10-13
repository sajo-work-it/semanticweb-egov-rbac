
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.education;

namespace materTestCore2.Repos.education
{
    public class CourseRepository : ResourceRepository<course>
    {
        public CourseRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public CourseRepository(Uri uri)
            : base(uri)
        {
        }
    }
}