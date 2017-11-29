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
    public class AchatController : ApiController
    {
        [JwtAuthentication]
        public IEnumerable<Achat> Get()
        {
            return AchatDAO.GetAllAchat();
        }

        [JwtAuthentication]
        public Achat Get(int id_musique, string mail)
        {
            return AchatDAO.Get(id_musique, mail);
        }

        [JwtAuthentication]
        public Achat Post(Achat achat)
        {
            return AchatDAO.Create(achat);
        }

        [JwtAuthentication]
        public string Put(Achat achat)
        {
            if (AchatDAO.Update(achat))
            {
                return "OK";
            }
            return "NOT_PUT";
        }

        [JwtAuthentication]
        public string Delete(int id_musique, string mail)
        {
            if (AchatDAO.Delete (id_musique, mail))
            {
                return "OK";
            }
            return "NOT_DELETE";
        }
    }
}
