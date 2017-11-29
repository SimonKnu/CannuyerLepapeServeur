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

    public class PlaylistController : ApiController
    {
        [JwtAuthentication]
        public IEnumerable<Playlist> Get()
        {
            return PlaylistDAO.GetAllPlaylist();
        }

        [JwtAuthentication]
        public Playlist Get(int id_playlist)
        {
            return PlaylistDAO.Get(id_playlist);
        }

        [JwtAuthentication]
        public IEnumerable<Playlist> Get(string mail)
        {
            return PlaylistDAO.GetList(mail);
        }

        [JwtAuthentication]
        public Playlist Post(Playlist playlist)
        {
            return PlaylistDAO.Create(playlist);
        }

        [JwtAuthentication]
        public string Put(Playlist playlist)
        {
            if (PlaylistDAO.Update(playlist))
            {
                return "OK";
            }
            return "NOT_PUT";
        }

        [JwtAuthentication]
        public string Delete(int id_playlist, string mail)
        {
            if (PlaylistDAO.Delete(id_playlist, mail))
            {
                return "OK";
            }
            return"NOT_DELETE";
        }
    }
}
