using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{  
  public class DB
  {
    public static SqlConnection Connection()
    {
      SqlConnection connection = new SqlConnection(DBConfiguration.ConnectionString);
      return connection;
    }
  }
}