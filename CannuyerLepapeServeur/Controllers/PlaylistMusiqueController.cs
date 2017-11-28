using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CannuyerLepapeServeur.Models;

namespace CannuyerLepapeServeur.Controllers
{
    public class PlaylistMusiqueController : ApiController
    {
        public IEnumerable<PlaylistMusique> Get()
        {
            return PlaylistMusiqueDAO.GetAllPlaylistMusique();
        }

        public PlaylistMusique Get(int id_musique, int id_playlist)
        {
            return PlaylistMusiqueDAO.Get(id_musique, id_playlist);
        }

        public PlaylistMusique Post(PlaylistMusique playlistMusique)
        {
            return PlaylistMusiqueDAO.Create(playlistMusique);
        }

        // PUT: api/PlaylistMusique/5
        public void Put(int id, [FromBody]string value)
        {
        }

        public string Delete(int id_musique, int id_playlist)
        {
            if (PlaylistMusiqueDAO.Delete(id_musique, id_playlist))
            {
                return "OK";
            }
            return "NOT_DELETE";
        }

        public string Delete(int id_playlist)
        {
            if (PlaylistMusiqueDAO.Delete(id_playlist))
            {
                return "OK";
            }
            return "NOT_DELETE";
        }
    }
}
