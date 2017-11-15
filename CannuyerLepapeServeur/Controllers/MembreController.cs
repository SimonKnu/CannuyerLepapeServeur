using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CannuyerLepapeServeur.Controllers
{
    public class MembreController : ApiController
    {
        // GET: api/Membre
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Membre/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Membre
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Membre/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Membre/5
        public void Delete(int id)
        {
        }
    }
}
