using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public class PlaylistMusique
    {
        public int Id_musique
        {
            get;
            set;
        }

        public int Id_Playlist
        {
            get;
            set;
        }

        public PlaylistMusique(int id_musique, int id_playlist)
        {
            Id_musique = id_musique;
            Id_Playlist = id_playlist;
        }

        public PlaylistMusique() : this(0, 0) { }
    }
}