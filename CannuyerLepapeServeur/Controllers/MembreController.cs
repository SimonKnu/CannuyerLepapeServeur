using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CannuyerLepapeServeur.Models;

namespace CannuyerLepapeServeur.Controllers
{
    public class MembreController : ApiController
    {
 
        public IEnumerable<Membre> Get()
        {
            return MembreDAO.GetAllMembre();
        }

        public Membre Get(string pseudo_membre)
        {
            return MembreDAO.Get(pseudo_membre);
        }

        public Membre Post(Membre membre)
        {
            return MembreDAO.Create(membre);
        }

        public IHttpActionResult Put(Membre membre)
        {
            if (MembreDAO.Update(membre))
            {
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(string pseudo_membre)
        {
            if (MembreDAO.Delete(pseudo_membre))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
