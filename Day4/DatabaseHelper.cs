using Microsoft.Data.SqlClient;

public static class DatabaseHelper
{
    public static string ConnectionString = "Server=10.4.24.116;Database=DEMO;User Id=ITAdmin;Password=ITadmin$2018; Trusted_Connection=false";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}