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

        public Achat Get(int id_musique, string mail)
        {
            return AchatDAO.Get(id_musique, mail);
        }

        public Achat Post(Achat achat)
        {
            return AchatDAO.Create(achat);
        }

        public IHttpActionResult Put(Achat achat)
        {
            if (AchatDAO.Update(achat))
            {
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(int id_musique, string mail)
        {
            if (AchatDAO.Delete (id_musique, mail))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
