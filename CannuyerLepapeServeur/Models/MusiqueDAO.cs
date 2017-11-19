using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public static class MusiqueDAO
    {

        private static readonly string QUERY = "SELECT * FROM musique";
        private static readonly string GET = QUERY + " WHERE id_musique = @id_musique";
        private static readonly string DELETE = "DELETE FROM musique WHERE id_musique = @id_musique";
        private static readonly string CREATE = "INSERT INTO musique(auteur, titre, style, url, prix) OUTPUT INSERTED.id_musique VALUES (@auteur, @titre, @style, @url, @prix)";
        private static readonly string UPDATE = "UPDATE musique SET auteur = @auteur, titre = @titre, style = @style, url = @url, prix =  @prix WHERE id_musique = @id_musique";
        private static readonly string GETACHAT = "SELECT musique.* FROM musique inner join achat on achat.pseudo_membre like @pseudo_membre and achat.id_musique = musique.id_musique where achat.statut = @statut";

        public static List<Musique> GetAllMusique()
        {
            List<Musique> liste = new List<Musique>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(QUERY, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new Musique(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5)));
                }
            }

            return liste;
        }

        public static Musique Get(int id_musique)
        {
            Musique musique = null;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GET, connection);
                command.Parameters.AddWithValue("@id_musique", id_musique);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    musique = new Musique(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5));
                }
            }

            return musique;
        }

        public static List<Musique> GetAchat(string pseudo_membre, int statut)
        {
            List<Musique> liste = new List<Musique>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GETACHAT, connection);
                command.Parameters.AddWithValue("@pseudo_membre", pseudo_membre);
                command.Parameters.AddWithValue("@statut", statut);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    liste.Add(new Musique(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5)));
                }
            }

            return liste;
        }

        public static Musique Create(Musique musique)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(CREATE, connection);
                command.Parameters.AddWithValue("@auteur", musique.Auteur);
                command.Parameters.AddWithValue("@titre", musique.Titre);
                command.Parameters.AddWithValue("@style", musique.Style);
                command.Parameters.AddWithValue("@url", musique.Url);
                command.Parameters.AddWithValue("@prix", musique.Prix);

                musique.Id_musique = (int)command.ExecuteScalar();
            }

            return musique;
        }

        public static bool Delete(int id_musique)
        {
            bool estSupprimee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DELETE, connection);
                command.Parameters.AddWithValue("@id_musique", id_musique);

                estSupprimee = command.ExecuteNonQuery() != 0; ;
            }

            return estSupprimee;
        }

        public static bool Update(Musique musique)
        {
            bool aEteModifiee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(UPDATE, connection);
                command.Parameters.AddWithValue("@id_musique", musique.Id_musique);
                command.Parameters.AddWithValue("@auteur", musique.Auteur);
                command.Parameters.AddWithValue("@titre", musique.Titre);
                command.Parameters.AddWithValue("@style", musique.Style);
                command.Parameters.AddWithValue("@url", musique.Url);
                command.Parameters.AddWithValue("@prix", musique.Prix);

                aEteModifiee = command.ExecuteNonQuery() != 0; ;
            }

            return aEteModifiee;
        }
    }
}