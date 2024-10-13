
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.education;

namespace materTestCore2.Repos.education
{
    public class ExamRepository : ResourceRepository<exam>
    {
        public ExamRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public ExamRepository(Uri uri)
            : base(uri)
        {
        }
    }
}