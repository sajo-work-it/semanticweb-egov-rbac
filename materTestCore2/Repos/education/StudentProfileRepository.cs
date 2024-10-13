
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.education;

namespace materTestCore2.Repos.education
{
    public class StudentProfileRepository : ResourceRepository<StudentProfile>
    {
        public StudentProfileRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public StudentProfileRepository(Uri uri)
            : base(uri)
        {
        }
    }
}