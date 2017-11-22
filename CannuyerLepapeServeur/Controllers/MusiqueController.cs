using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CannuyerLepapeServeur.Models;

namespace CannuyerLepapeServeur.Controllers
{
    public class MusiqueController : ApiController
    {
        public IEnumerable<Musique> Get()
        {
            return MusiqueDAO.GetAllMusique();
        }

        public Musique Get(int id_musique)
        {
            return MusiqueDAO.Get(id_musique);
        }

        public IEnumerable<Musique> Get(string mail, int statut)
        {
            return MusiqueDAO.GetAchat(mail, statut);
        }

        public Musique Post(Musique musique)
        {
            return MusiqueDAO.Create(musique);
        }

        public IHttpActionResult Put(Musique musique)
        {
            if (MusiqueDAO.Update(musique))
            {
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(int id_musique)
        {
            if (MusiqueDAO.Delete(id_musique))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
