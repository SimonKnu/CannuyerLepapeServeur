using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CannuyerLepapeServeur.Models;

namespace CannuyerLepapeServeur.Controllers
{
    public class AchatController : ApiController
    {
        public IEnumerable<Achat> Get()
        {
            return AchatDAO.GetAllAchat();
        }

        public Achat Get(int id_musique, string pseudo_membre)
        {
            return AchatDAO.Get(id_musique, pseudo_membre);
        }

        public Achat Post(Achat achat)
        {
            return AchatDAO.Create(achat);
        }

        // PUT: api/Achat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        public IHttpActionResult Delete(int id_musique, string pseudo_membre)
        {
            if (AchatDAO.Delete (id_musique, pseudo_membre))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
