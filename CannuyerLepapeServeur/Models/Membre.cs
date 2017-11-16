using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public class Membre
    {
        public string Pseudo_membre
        {
            get;
            set;
        }

        public string Mot_de_passe
        {
            get;
            set;
        }

        public string Nom
        {
            get;
            set;
        }

        public string Prenom
        {
            get;
            set;
        }

        public string Mail
        {
            get;
            set;
        }

        public string Telephone
        {
            get;
            set;
        }

        public string Date_naissance
        {
            get;
            set;
        }

        public string Ville
        {
            get;
            set;
        }

        public string Pays
        {
            get;
            set;
        }

        public string Rue
        {
            get;
            set;
        }

        public int Code_postal
        {
            get;
            set;
        }

        public decimal Argent
        {
            get;
            set;
        }

        public string Date_inscription
        {
            get;
            set;
        }

        public bool Administrateur
        {
            get;
            set;
        }

        public Membre() { }

        public Membre(string pseudo_membre, string mot_de_passe, string nom, string prenom, string mail, string telephone, string date_naissance, string pays, string ville, string rue, int code_postal, decimal argent, string date_inscription, bool administrateur)
        {
            Pseudo_membre = pseudo_membre;
            Mot_de_passe = mot_de_passe;
            Nom = nom;
            Prenom = prenom;
            Mail = mail;
            Telephone = telephone;
            Date_naissance = date_naissance;
            Ville = ville;
            Pays = pays;
            Rue = rue;
            Code_postal = code_postal;
            Argent = argent;
            Date_inscription = date_inscription;
            Administrateur = administrateur;
        }


    }
}