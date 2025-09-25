using Day4_2;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.Pkcs;


public class ProductCRUD
{
    public List<Product> GetAll (){
        var result = new List<Product>();
        
        using(SqlConnection conn = DatabaseHelper.GetSqlConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Test_Product", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Product
                {
                    Id = Convert.ToInt16(reader["id"]),
                    Name = reader["name"].ToString(),
                    Price = Convert.ToDecimal(reader["price"]),
                    Description = reader["description"].ToString()

                });
            }

        }
        return result;
    }

    public void Create(Product pr)
    {
        using(SqlConnection conn = DatabaseHelper.GetSqlConnection())
        {
            conn.Open();
            string query = "INSERT INTO Test_Product(name, price, description) VALUES(@name, @price, @description)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", pr.Name);
            cmd.Parameters.AddWithValue("@price", pr.Price);
            cmd.Parameters.AddWithValue("@description", pr.Description);
            cmd.ExecuteNonQuery();
        }
    }
    public void Update(int id, decimal priceNew)
    {
        using(SqlConnection conn = DatabaseHelper.GetSqlConnection())
        {
            conn.Open();
            String query = "UPDATE Test_Product SET price=@price WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@price", priceNew);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        using(SqlConnection conn = DatabaseHelper.GetSqlConnection())
        {
            conn.Open();
            String query = "DELETE FROM Test_Product WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}