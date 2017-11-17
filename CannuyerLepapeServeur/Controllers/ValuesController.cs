using JWT.Filters;
using System.Collections.Generic;
using System.Web.Http;

namespace CannuyerLepapeServeur.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [JwtAuthentication]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [JwtAuthentication]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [JwtAuthentication]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [JwtAuthentication]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [JwtAuthentication]
        public void Delete(int id)
        {
        }

    }
}
