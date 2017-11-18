using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public static class AchatDAO
    {
        private static readonly string QUERY = "SELECT * FROM achat";
        private static readonly string GET = QUERY + " WHERE pseudo_membre = @pseudo_membre and id_musique = @id_musique";
        private static readonly string CREATE = "INSERT INTO achat(pseudo_membre, id_musique, statut) VALUES (@pseudo_membre, @id_musique, @statut)";
        private static readonly string DELETE = "DELETE FROM achat  WHERE pseudo_membre = @pseudo_membre and id_musique = @id_musique";
        private static readonly string UPDATE = "UPDATE achat SET statut = @statut WHERE pseudo_membre = @pseudo_membre and id_musique = @id_musique";

        public static List<Achat> GetAllAchat()
        {
            List<Achat> liste = new List<Achat>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(QUERY, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new Achat(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2)));
                }
            }

            return liste;
        }

        public static Achat Get(int id_musique, string pseudo_membre)
        {
            Achat achat = null;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GET, connection);
                command.Parameters.AddWithValue("@id_musique", id_musique);
                command.Parameters.AddWithValue("@pseudo_membre", pseudo_membre);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    achat = new Achat(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2));
                }
            }

            return achat;
        }

        public static bool Delete(int id_musique, string pseudo_membre)
        {
            bool estSupprimee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DELETE, connection);
                command.Parameters.AddWithValue("@id_musique", id_musique);
                command.Parameters.AddWithValue("@pseudo_membre", pseudo_membre);

                estSupprimee = command.ExecuteNonQuery() != 0; ;
            }

            return estSupprimee;
        }

        public static Achat Create(Achat achat)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(CREATE, connection);
                command.Parameters.AddWithValue("@pseudo_membre", achat.Pseudo_membre);
                command.Parameters.AddWithValue("@id_musique", achat.Id_musique);
                command.Parameters.AddWithValue("@statut", achat.Statut);

                command.ExecuteScalar();
            }

            return achat;
        }

        public static bool Update(Achat achat)
        {
            bool aEteModifiee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(UPDATE, connection);
                command.Parameters.AddWithValue("@pseudo_membre", achat.Pseudo_membre);
                command.Parameters.AddWithValue("@id_musique", achat.Id_musique);
                command.Parameters.AddWithValue("@statut", achat.Statut);

                aEteModifiee = command.ExecuteNonQuery() != 0; ;
            }

            return aEteModifiee;
        }
    }
}