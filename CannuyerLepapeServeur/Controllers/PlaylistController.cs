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


        public Playlist Post(Playlist playlist)
        {
            return PlaylistDAO.Create(playlist);
        }


        public IHttpActionResult Put(Playlist playlist)
        {
            if (PlaylistDAO.Update(playlist))
            {
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(int id_playlist)
        {
            if (PlaylistDAO.Delete(id_playlist))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
