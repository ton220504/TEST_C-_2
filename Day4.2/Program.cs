using Microsoft.Data.SqlClient;
using Day4_2;
using System.Data;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //                          select với SqlDataReder
        //using(SqlConnection conn = new SqlConnection(cns))
        //{
        //    conn.Open();
        //    Console.OutputEncoding = System.Text.Encoding.UTF8;
        //    string query = "SELECT * FROM Test_Product";
        //    SqlCommand cmd = new SqlCommand(query, conn);

        //    SqlDataReader reder = cmd.ExecuteReader();
        //    Console.WriteLine("Danh sách Sản Phẩm: ");
        //    while (reder.Read())
        //    {
        //        Console.WriteLine($"{reder["ID"]} - {reder["Name"]} - {reder["Price"]} - {reder["Description"]}");
        //    }

        //}

        //----------------------------------------------------------------------------------------------------------------
        //                                  select với SqlDataAdapter + DataTable
        //DataTable dt = new DataTable();
        //using(SqlConnection conn = new SqlConnection(cns))
        //{
        //    conn.Open();
        //    Console.OutputEncoding = System.Text.Encoding.UTF8;
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Test_Product", conn);
        //    da.Fill(dt);
        //}

        //foreach(DataRow dr in dt.Rows)
        //{
        //    Console.WriteLine($"{dr["ID"]} - {dr["Name"]} - {dr["Price"]} - {dr["Description"]}");
        //}
        //----------------------------------------------------------------------------------------------------------------

        var repo = new ProductCRUD();
        while (true) {
            Console.WriteLine("\n==========Quản lý Sản Phẩm==========");
            Console.WriteLine("1. Xem danh sách Sản Phẩm.");
            Console.WriteLine("2. Thêm mới Sản Phẩm.");
            Console.WriteLine("3. Cập nhật giá Sản Phẩm.");
            Console.WriteLine("4. Xóa Sản Phẩm.");
            Console.WriteLine("0. Thoát.");
            Console.Write("Chọn ");
            string choice = Console.ReadLine();

            int id;


            switch (choice)
            {
                case "1":
                    var list = repo.GetAll();
                    foreach (var item in list)
                    {
                        Console.WriteLine($"Tên: {item.Name} - Giá: {item.Price} - Mô tả: {item.Description}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Nhập tên: "); string ten = Console.ReadLine();
                    Console.WriteLine("Nhập giá: "); decimal gia = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập mô tả: "); string mota = Console.ReadLine();

                    repo.Create(new Product { Name = ten, Price = gia, Description = mota });
                    Console.WriteLine("Thêm thành công!");
                    break;
                case "3":
                    Console.WriteLine("Nhập ID: "); id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập giá mới: "); decimal giaNew = decimal.Parse(Console.ReadLine());

                    repo.Update(id, giaNew);
                    Console.WriteLine("Cập nhật thành công!");
                    break;
                case "4":
                    Console.WriteLine("Nhập Id: "); id = int.Parse(Console.ReadLine());
                    repo.Delete(id);
                    Console.WriteLine("Xóa thành công!");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Không có lựa chọn nào phù hợp.");
                    break;

            }

        }
    }
}