using Microsoft.Data.SqlClient;

namespace Day4_2{
    public static class DatabaseHelper
    {
        public static String ConnectionString = "Server=10.4.24.116;Database=DEMO;User Id=ITAdmin;Password=ITadmin$2018;TrustServerCertificate=True;";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
