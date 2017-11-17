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

        [JwtAuthentication]
        public Membre Get(string pseudo_membre)
        {
            return MembreDAO.Get(pseudo_membre);
        }

        public IHttpActionResult Get(string mail, string password)
        {
            if (MembreDAO.GetConnexion(mail,password))
            {
                return Ok();
            }
            return BadRequest();
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
