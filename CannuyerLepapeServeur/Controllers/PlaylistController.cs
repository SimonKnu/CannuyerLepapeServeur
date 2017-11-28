using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CannuyerLepapeServeur.Models;


namespace CannuyerLepapeServeur.Controllers
{

    public class PlaylistController : ApiController
    {
        public IEnumerable<Playlist> Get()
        {
            return PlaylistDAO.GetAllPlaylist();
        }

        public Playlist Get(int id_playlist)
        {
            return PlaylistDAO.Get(id_playlist);
        }

        public IEnumerable<Playlist> Get(string mail)
        {
            return PlaylistDAO.GetList(mail);
        }

        public Playlist Post(Playlist playlist)
        {
            return PlaylistDAO.Create(playlist);
        }


        public string Put(Playlist playlist)
        {
            if (PlaylistDAO.Update(playlist))
            {
                return "OK";
            }
            return "NOT_PUT";
        }

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
