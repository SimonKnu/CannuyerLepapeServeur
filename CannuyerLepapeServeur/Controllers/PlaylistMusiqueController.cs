﻿using System;
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

        // POST: api/PlaylistMusique
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PlaylistMusique/5
        public void Put(int id, [FromBody]string value)
        {
        }

        public IHttpActionResult Delete(int id_musique, int id_playlist)
        {
            if (PlaylistMusiqueDAO.Delete(id_musique, id_playlist))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}