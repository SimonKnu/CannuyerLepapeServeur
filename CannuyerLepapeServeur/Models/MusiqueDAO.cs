using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public static class MusiqueDAO
    {

        private static readonly string GETMUSIQUENOBUY = "SELECT * FROM musique LEFT JOIN achat on musique.id_musique = achat.id_musique WHERE achat.mail is null";
        private static readonly string DELETE = "DELETE FROM musique WHERE id_musique = @id_musique";
        private static readonly string CREATE = "INSERT INTO musique(auteur, titre, style, preview, musiquecomplet, image, prix) OUTPUT INSERTED.id_musique VALUES (@auteur, @titre, @style, @preview, @musiquecomplet, @image, @prix)";
        private static readonly string UPDATE = "UPDATE musique SET auteur = @auteur, titre = @titre, style = @style, preview = @preview, musiquecomplet = @musiquecomplet, image = @image, prix =  @prix WHERE id_musique = @id_musique";
        private static readonly string GETACHAT = "SELECT musique.* FROM musique INNER JOIN achat ON achat.id_musique = musique.id_musique WHERE achat.statut = @statut AND achat.mail LIKE @mail";
        private static readonly string GETPLAYLIST= "SELECT musique.* FROM musique inner join playlistmusique on playlistmusique.id_musique = musique.id_musique where playlistmusique.id_playlist = @id_playlist";

        public static List<Musique> GetAllMusique()
        {
            List<Musique> liste = new List<Musique>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GETMUSIQUENOBUY, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new Musique(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDecimal(7)));
                }
            }

            return liste;
        }

        public static List<Musique> Get(int id_playlist)
        {
            List<Musique> liste = new List<Musique>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GETPLAYLIST, connection);
                command.Parameters.AddWithValue("@id_playlist", id_playlist);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new Musique(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDecimal(7)));
                }
            }

            return liste;
        }

        public static List<Musique> GetAchat(string mail, int statut)
        {
            List<Musique> liste = new List<Musique>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GETACHAT, connection);
                command.Parameters.AddWithValue("@mail", mail);
                command.Parameters.AddWithValue("@statut", statut);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new Musique(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDecimal(7)));
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
                command.Parameters.AddWithValue("@preview", musique.Preview);
                command.Parameters.AddWithValue("@musiquecomplet", musique.Musiquecomplet);
                command.Parameters.AddWithValue("@image", musique.Image);
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
                command.Parameters.AddWithValue("@preview", musique.Preview);
                command.Parameters.AddWithValue("@musiquecomplet", musique.Musiquecomplet);
                command.Parameters.AddWithValue("@image", musique.Image);
                command.Parameters.AddWithValue("@prix", musique.Prix);

                aEteModifiee = command.ExecuteNonQuery() != 0;
            }

            return aEteModifiee;
        }
    }
}