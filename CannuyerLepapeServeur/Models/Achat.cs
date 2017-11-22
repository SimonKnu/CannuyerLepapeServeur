using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public class Achat
    {
        public string Mail
        {
            get;
            set;
        }

        public int Id_musique
        {
            get;
            set;
        }

        public int Statut
        {
            get;
            set;
        }

        public Achat(string mail, int id_musique, int statut)
        {
            Mail = mail;
            Id_musique = id_musique;
            Statut = statut;
        }

        public Achat(int statut) : this("0", 0, statut) { }

        public Achat() { }
    }
}