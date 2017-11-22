using System.Net;
using System.Web.Http;
using JWT.Filters;
using CannuyerLepapeServeur.Models;

namespace CannuyerLepapeServeur.Controllers
{
    public class TokenController : ApiController
    {
        // THis is naive endpoint for demo, it should use Basic authentication to provide token or POST request
        [AllowAnonymous]
        public string Get(string mail, string mot_de_passe)
        {
            if (CheckUser(mail, mot_de_passe))
            {
                return JwtManager.GenerateToken(mail);
            }

            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return "error";
        }

        public bool CheckUser(string mail, string password)
        {
            return MembreDAO.GetConnexion(mail, password);
        }
    }
}