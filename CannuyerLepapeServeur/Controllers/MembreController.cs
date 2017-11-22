using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CannuyerLepapeServeur.Models;
using JWT.Filters;

namespace CannuyerLepapeServeur.Controllers
{
    public class MembreController : ApiController
    {
        [JwtAuthentication]
        public IEnumerable<Membre> Get()
        {
            return MembreDAO.GetAllMembre();
        }

        
        public Membre Get(string mail)
        {
            return MembreDAO.Get(mail);
        }

        public bool Get(string mail, string mot_de_passe)
        {
            return MembreDAO.GetConnexion(mail, mot_de_passe);
        }


        public Membre Post(Membre membre)
        {
            return MembreDAO.Create(membre);
        }

        [JwtAuthentication]
        public IHttpActionResult Put(Membre membre)
        {
            if (MembreDAO.Update(membre))
            {
                return Ok();
            }
            return BadRequest();
        }

        [JwtAuthentication]
        public IHttpActionResult Delete(string mail)
        {
            if (MembreDAO.Delete(mail))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
