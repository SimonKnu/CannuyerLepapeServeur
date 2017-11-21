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
        public string Get(string pseudo, string password)
        {
            if (CheckUser(pseudo, password))
            {
                return JwtManager.GenerateToken(pseudo);
            }

            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return "error";
        }

        public bool CheckUser(string username, string password)
        {
            return MembreDAO.GetConnexion(username, password);
        }
    }
}