﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public static class MembreDAO
    {
        private static readonly string VERIFICATION = "SELECT * FROM membre WHERE mail = @mail AND mot_de_passe = @mot_de_passe";
        private static readonly string QUERY = "SELECT * FROM membre";
        private static readonly string GET = QUERY+ " WHERE mail = @mail";
        private static readonly string CREATE = "INSERT INTO membre(mail, mot_de_passe, nom, prenom, telephone, date_naissance, pays, ville, rue, code_postal, argent, date_inscription, administrateur) VALUES (@mail, @mot_de_passe, @nom, @prenom, @telephone, @date_naissance, @pays, @ville, @rue, @code_postal, 0, @date_inscription, @administrateur)";
        private static readonly string DELETE = "DELETE FROM membre WHERE mail = @mail";
        private static readonly string UPDATE = "UPDATE membre SET mot_de_passe = @mot_de_passe, nom = @nom, prenom = @prenom, telephone = @telephone, date_naissance = @date_naissance, pays = @pays, ville = @ville, rue = @rue, code_postal = @code_postal, argent = @argent, date_inscription = @date_inscription, administrateur = @administrateur WHERE mail = @mail";

        public static List<Membre> GetAllMembre()
        {
            List<Membre> liste = new List<Membre>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(QUERY, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new Membre(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetInt32(9), reader.GetDecimal(10), reader.GetString(11), reader.GetBoolean(12)));
                }
            }

            return liste;
        }

        public static Membre Create(Membre membre)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(CREATE, connection);
                command.Parameters.AddWithValue("@mail", membre.Mail);
                command.Parameters.AddWithValue("@mot_de_passe", membre.Mot_de_passe);
                command.Parameters.AddWithValue("@nom", membre.Nom);
                command.Parameters.AddWithValue("@prenom", membre.Prenom);
                command.Parameters.AddWithValue("@telephone", membre.Telephone);
                command.Parameters.AddWithValue("@date_naissance", membre.Date_naissance);
                command.Parameters.AddWithValue("@pays", membre.Pays);
                command.Parameters.AddWithValue("@ville", membre.Ville);
                command.Parameters.AddWithValue("@rue", membre.Rue);
                command.Parameters.AddWithValue("@code_postal", membre.Code_postal);
                command.Parameters.AddWithValue("@date_inscription", membre.Date_inscription);
                command.Parameters.AddWithValue("@administrateur", membre.Administrateur);

                command.ExecuteScalar();
            }

            return membre;
        }

        public static bool Delete(string mail)
        {
            bool estSupprimee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DELETE, connection);
                command.Parameters.AddWithValue("@mail", mail);

                estSupprimee = command.ExecuteNonQuery() != 0; ;
            }

            return estSupprimee;
        }

        public static bool Update(Membre membre)
        {
            bool aEteModifiee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(UPDATE, connection);
                command.Parameters.AddWithValue("@mail", membre.Mail);
                command.Parameters.AddWithValue("@mot_de_passe", membre.Mot_de_passe);
                command.Parameters.AddWithValue("@nom", membre.Nom);
                command.Parameters.AddWithValue("@prenom", membre.Prenom);
                command.Parameters.AddWithValue("@telephone", membre.Telephone);
                command.Parameters.AddWithValue("@date_naissance", membre.Date_naissance);
                command.Parameters.AddWithValue("@pays", membre.Pays);
                command.Parameters.AddWithValue("@ville", membre.Ville);
                command.Parameters.AddWithValue("@rue", membre.Rue);
                command.Parameters.AddWithValue("@code_postal", membre.Code_postal);
                command.Parameters.AddWithValue("@argent", membre.Argent);
                command.Parameters.AddWithValue("@date_inscription", membre.Date_inscription);
                command.Parameters.AddWithValue("@administrateur", membre.Administrateur);

                aEteModifiee = command.ExecuteNonQuery() != 0; ;
            }

            return aEteModifiee;
        }

        public static Membre Get(string mail)
        {
            Membre membre = null;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GET, connection);
                command.Parameters.AddWithValue("@mail", mail);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    membre = new Membre(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetInt32(9), reader.GetDecimal(10), reader.GetString(11), reader.GetBoolean(12));
                }
            }

            return membre;
        }

        public static bool GetConnexion(string mail, string password)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(VERIFICATION, connection);
                command.Parameters.AddWithValue("@mail", mail);
                command.Parameters.AddWithValue("@mot_de_passe", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
            }
            return false;
        }
    }
}