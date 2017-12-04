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
    public class MusiqueController : ApiController
    {
        public IEnumerable<Musique> Get()
        {
            return MusiqueDAO.GetAllMusique();
        }

        [JwtAuthentication]
        public IEnumerable<Musique> Get(int id_playlist)
        {
            return MusiqueDAO.Get(id_playlist);
        }


        [JwtAuthentication]
        public IEnumerable<Musique> Get(string mail, int statut)
        {
            return MusiqueDAO.GetAchat(mail, statut);
        }

        [JwtAuthentication]
        public Musique Post(Musique musique)
        {
            return MusiqueDAO.Create(musique);
        }

        [JwtAuthentication]
        public string Put(Musique musique)
        {
            if (MusiqueDAO.Update(musique))
            {
                return "OK";
            }
            return "NOT_PUT";
        }

        [JwtAuthentication]
        public string Delete(int id_musique)
        {
            if (MusiqueDAO.Delete(id_musique))
            {
                return "OK";
            }
            return "NOT_DELETE";
        }
    }
}
