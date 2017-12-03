using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CannuyerLepapeServeur.Models
{
    public class DataBase
    {
      //  public static readonly string CONNECTION_STRING = @"Server=tcp:trackcity.database.windows.net,1433;Initial Catalog=TrackCity;Persist Security Info=False;User ID=Yorick;Password=Helha2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static readonly string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CityTrackBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(DataBase.CONNECTION_STRING);
        }
    }
}