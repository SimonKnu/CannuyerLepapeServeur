﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public class PlaylistDAO
    {

        private static readonly string QUERY = "SELECT * FROM playlist";       
        private static readonly string GET = QUERY + " WHERE id_playlist = @id_playlist";
        private static readonly string CREATE = "INSERT INTO playlist(id_playlist, nom, date_creation, pseudo_membre) VALUES (@id_playlist, @nom, @date_creation, @pseudo_membre)";
        private static readonly string DELETE = "DELETE FROM playlist WHERE id_playlist = @id_playlist";

        public static List<Playlist> GetAllPlaylist()
        {
            List<Playlist> todos = new List<Playlist>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(QUERY, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    todos.Add(new Playlist(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
            }

            return todos;
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

        public static bool Delete(int id_playlist)
        {
            bool estSupprimee = false;

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DELETE, connection);
                command.Parameters.AddWithValue("@id_playlist", id_playlist);

                estSupprimee = command.ExecuteNonQuery() != 0; ;
            }

            return estSupprimee;
        }
    }
}