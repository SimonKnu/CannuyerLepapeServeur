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
        public string Put(Membre membre)
        {
            if (MembreDAO.Update(membre))
            {
                return "OK";
            }
            return "NOT_PUT";
        }
        [JwtAuthentication]
        public string Put(string mail, string mot_de_passe)
        {
            if (MembreDAO.UpdatePassWord(mail,mot_de_passe))
            {
                return "OK";
            }
            return "NOT_PUT";
        }
        [JwtAuthentication]
        public string Put(string mail, decimal argent)
        {
            if (MembreDAO.UpdateArgent(mail,argent))
            {
                return "OK";
            }
            return "NOT_PUT";
        }


        [JwtAuthentication]
        public string Delete(string mail)
        {
            if (MembreDAO.Delete(mail))
            {
                return "OK";
            }
            return "NOT_DELETE";
        }
    }
}
