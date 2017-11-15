using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public class AchatDAO
    {
        private static readonly string QUERY = "SELECT * FROM achat";

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
                    liste.Add(new Achat(reader.GetString(0), reader.GetInt32(1)));
                }
            }

            return liste;
        }
    }
}