using System.Collections.Generic;
using System.Web.Http;

namespace CatLister.Controllers
{
    public class PersonApiController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
