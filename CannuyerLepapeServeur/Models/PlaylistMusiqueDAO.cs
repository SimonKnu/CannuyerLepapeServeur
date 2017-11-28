using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public static class PlaylistMusiqueDAO
    {

        private static readonly string QUERY = "SELECT * FROM playlistmusique";       
        private static readonly string GET = QUERY + " WHERE id_musique = @id_musique and id_playlist = @id_playlist";
        private static readonly string CREATE = "INSERT INTO playlistmusique(id_musique, id_playlist)  VALUES (@id_musique, @id_playlist)";
        private static readonly string DELETE = "DELETE FROM playlistmusique WHERE id_musique = @id_musique and id_playlist = @id_playlist";
        private static readonly string DELETEALL = "DELETE FROM playlistmusique WHERE id_playlist = @id_playlist";

        public static List<PlaylistMusique> GetAllPlaylistMusique()
        {
            List<PlaylistMusique> todos = new List<PlaylistMusique>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(QUERY, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    todos.Add(new PlaylistMusique(reader.GetInt32(0), reader.GetInt32(1)));
                }
            }

            return todos;
        }


        public static PlaylistMusique Get(int id_musique, int id_playlist)
        {
            PlaylistMusique playlistMusique = null;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(GET, connection);
                command.Parameters.AddWithValue("@id_musique", id_musique);
                command.Parameters.AddWithValue("@id_playlist", id_playlist);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    playlistMusique = new PlaylistMusique(reader.GetInt32(0), reader.GetInt32(1));
                }
            }

            return playlistMusique;
        }

        public static bool Delete(int id_musique, int id_playlist)
        {
            bool estSupprimee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DELETE, connection);
                command.Parameters.AddWithValue("@id_musique", id_musique);
                command.Parameters.AddWithValue("@id_playlist", id_playlist);

                estSupprimee = command.ExecuteNonQuery() != 0; ;
            }

            return estSupprimee;
        }

        public static bool Delete(int id_playlist)
        {
            bool estSupprimee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DELETEALL, connection);
                command.Parameters.AddWithValue("@id_playlist", id_playlist);

                estSupprimee = command.ExecuteNonQuery() != 0; ;
            }

            return estSupprimee;
        }

        public static PlaylistMusique Create(PlaylistMusique playlistMusique)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(CREATE, connection);
                command.Parameters.AddWithValue("@id_musique", playlistMusique.Id_musique);
                command.Parameters.AddWithValue("@id_playlist", playlistMusique.Id_Playlist);
                command.ExecuteScalar();
            }

            return playlistMusique;
        }
    }
}