using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public static class PlaylistDAO
    {

        private static readonly string QUERY = "SELECT * FROM playlist";       
        private static readonly string GET = QUERY + " WHERE id_playlist = @id_playlist";
        private static readonly string GETLIST = QUERY + " WHERE mail = @mail";
        private static readonly string CREATE = "INSERT INTO playlist(nom, date_creation, mail) OUTPUT INSERTED.id_playlist VALUES (@nom, @date_creation, @mail)";
        private static readonly string DELETE = "DELETE FROM playlist WHERE id_playlist = @id_playlist and mail like @mail";
        private static readonly string UPDATE = "UPDATE playlist SET nom = @nom WHERE id_playlist = @id_playlist";

        public static List<Playlist> GetAllPlaylist()
        {
            List<Playlist> playlist = new List<Playlist>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(QUERY, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    playlist.Add(new Playlist(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
            }

            return playlist;
        }
        public static List<Playlist> GetList(String mail)
        {
            List<Playlist> playlist = new List<Playlist>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GETLIST, connection);
                command.Parameters.AddWithValue("@mail", mail);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    playlist.Add(new Playlist(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
            }

            return playlist;
        }


        public static Playlist Get(int id_playlist)
        {
            Playlist playlist = null;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GET, connection);
                command.Parameters.AddWithValue("@id_playlist", id_playlist);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    playlist = new Playlist(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                }
            }

            return playlist;
        }

        public static bool Delete(int id_playlist, string mail)
        {
            bool estSupprimee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DELETE, connection);
                command.Parameters.AddWithValue("@id_playlist", id_playlist);
                command.Parameters.AddWithValue("@mail", mail);

                estSupprimee = command.ExecuteNonQuery() != 0; ;
            }

            return estSupprimee;
        }

        public static Playlist Create(Playlist playlist)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(CREATE, connection);
                command.Parameters.AddWithValue("@nom", playlist.Nom);
                command.Parameters.AddWithValue("@date_creation", playlist.Date_creation);
                command.Parameters.AddWithValue("@mail", playlist.Mail);

                playlist.Id_playlist = (int)command.ExecuteScalar();
            }

            return playlist;
        }

        public static bool Update(Playlist playlist)
        {
            bool aEteModifiee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(UPDATE, connection);
                command.Parameters.AddWithValue("@nom", playlist.Nom);
                command.Parameters.AddWithValue("@id_playlist", playlist.Id_playlist);

                aEteModifiee = command.ExecuteNonQuery() != 0; ;
            }

            return aEteModifiee;
        }
    }
}