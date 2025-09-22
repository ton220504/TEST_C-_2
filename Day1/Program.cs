////class
//public class NhanVien
//{
//    public string MaNV;
//    public string TenNV;
//    public decimal Luong;

//    public void HienThiThongTin()
//    {
//        Console.WriteLine($"Mã NV: {MaNV}\nTên: {TenNV}\nLương: {Luong}");
//    }
//}

//// Tạo object từ class
//public class Program
//{
//    public static void Main()
//    {
//        NhanVien nv1 = new NhanVien();
//        nv1.MaNV = "NV01";
//        nv1.TenNV = "Nguyen Van A";
//        nv1.Luong = 12000;
//        nv1.HienThiThongTin();

//    }
//}
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------

//Constructor
//public class NhanVien
//{
//    public string Msnv;
//    public string Hoten;
//    public decimal Luong;

//    public NhanVien()
//    {
//        Msnv = "msnv0";
//        Hoten = "Chưa có";
//        Luong = 0;
//    }

//    public NhanVien(string ma, string ten, decimal luong)
//    {
//        Msnv = ma;
//        Hoten = ten;
//        Luong = luong;
//    }
//    public void HienThi()
//    {
//        Console.WriteLine($"Mã NV: {Msnv}\nTên: {Hoten}\nLương: {Luong}");
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        NhanVien nv1 = new NhanVien();
//        NhanVien nv2 = new NhanVien("msnv1", "Toan", 15000000);

//        nv1.HienThi();
//        nv2.HienThi();
//    }
//}
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------
//Property (get, set, auto property)
public class NhanVien
{
    private string ten;
    private decimal luong;

    public string Ten
    {
        get { return ten; }
        set {
            if (!string.IsNullOrEmpty(value))
            {
                ten = value;
            }
        }
    }

    public decimal Luong
    {
        get { return luong; } 
        set
        {
            if (value >= 0) luong = value;
        }
    }

    public string Msnv { get; set; }

    public void HienThi()
    {
        Console.WriteLine($"MSNV: {Msnv}\nHo Ten: {Ten}\nLuong: {Luong}");
    }
}


public class Program
{
    public static void Main()
    {
        NhanVien nv1 = new NhanVien();
        nv1.Msnv = "1";
        nv1.Ten = "Toan";
        nv1.Luong = 15000000;

        nv1.HienThi();
    }
}