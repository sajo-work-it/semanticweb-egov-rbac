
using Semiodesk.Trinity;
using materTestCore2.Models.EGovModels.personal;

namespace materTestCore2.Repos.personal
{
    public class PersonRepository : ResourceRepository<PersonProfile>
    {
        public PersonRepository(string uri)
            : base(new UriRef(uri))
        {
        }

        public PersonRepository(Uri uri)
            : base(uri)
        {
        }
    }
}
