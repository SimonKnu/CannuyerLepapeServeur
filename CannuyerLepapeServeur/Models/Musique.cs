using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public class Musique
    {
        public int Id_musique
        {
            get;
            set;
        }

        public string Auteur
        {
            get;
            set;
        }

        public string Titre
        {
            get;
            set;
        }

        public string Style
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
        public string Image
        {
            get;
            set;
        }


        public decimal Prix
        {
            get;
            set;
        }

        public Musique(int id_musique, string auteur, string titre, string style, string url, string image, decimal prix)
        {
            Id_musique = id_musique;
            Auteur = auteur;
            Titre = titre;
            Style = style;
            Url = url;
            Image = image;
            Prix = prix;
        }

        public Musique(string auteur, string titre, string style, string url, string image, decimal prix):this(0, auteur, titre, style, url, image, prix) { }

        public Musique() { }
    }
}