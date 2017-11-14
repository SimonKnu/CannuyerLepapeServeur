using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public class Playlist
    {
        public int Id_playlist
        {
            get;
            set;
        }

        public string Nom
        {
            get;
            set;
        }

        public string Date_creation
        {
            get;
            set;
        }

        public string Pseudo_membre
        {
            get;
            set;
        }

        public Playlist(int id_playlist, string nom, string date_creation, string pseudo_membre)
        {
            Id_playlist = id_playlist;
            Nom = nom;
            Date_creation = date_creation;
            Pseudo_membre = pseudo_membre;
        }

        public Playlist(string nom, string date_creation, string pseudo_membre):this (0, nom, date_creation, pseudo_membre) { }
    }
}