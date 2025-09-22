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
//public class NhanVien
//{
//    private string ten;
//    private decimal luong;

//    public string Ten
//    {
//        get { return ten; }
//        set {
//            if (!string.IsNullOrEmpty(value))
//            {
//                ten = value;
//            }
//        }
//    }

//    public decimal Luong
//    {
//        get { return luong; } 
//        set
//        {
//            if (value >= 0) luong = value;
//        }
//    }

//    public string Msnv { get; set; }

//    public void HienThi()
//    {
//        Console.WriteLine($"MSNV: {Msnv}\nHo Ten: {Ten}\nLuong: {Luong}");
//    }
//}


//public class Program
//{
//    public static void Main()
//    {
//        NhanVien nv1 = new NhanVien();
//        nv1.Msnv = "1";
//        nv1.Ten = "Toan";
//        nv1.Luong = 15000000;

//        nv1.HienThi();
//    }
//}
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------
//  Kế thừa(Inheritance), Đa hình(Polymorphism)
//      inheritance: Class con kế thừa class cha.
//      virtual + override: cho phép ghi đè phương thức.
//      abstract: bắt buộc class con phải override.
//      interface: định nghĩa hành vi, class phải implement.

//class cha

public class NhanVien
{
    public string msnv { get; set; }
    public string hoten { get; set; }
    public decimal luongcoban { get; set; }
    public virtual decimal Tinhluong()
    {
        return luongcoban;
    }
}

//class con kế thừa
public class NhanVienPartTime : NhanVien
{
    public int Sogiolam { get; set; }
    public decimal Luongtheogiolam { get; set; }

    public override decimal Tinhluong()
    {
        return Sogiolam * Luongtheogiolam;
    }
}

public class Program
{
    public static void Main()
    {
        List<NhanVien> dsNhanVien = new List<NhanVien>();

        //thêm nhân viên fulltime
        NhanVien nv1 = new NhanVien { msnv = "ms01", hoten = "VanToan", luongcoban = 15000000 };
        dsNhanVien.Add(nv1);

        //thêm nhân viên part time
        NhanVienPartTime nv2 = new NhanVienPartTime { msnv = "ms02", hoten = "VanA", Sogiolam = 8, Luongtheogiolam = 25000 };
        dsNhanVien.Add(nv2);

        Console.WriteLine("Danh sách nhân viên:");
        foreach(var nv in dsNhanVien)
        {
            Console.WriteLine($"MSNV: {nv.msnv}, HoTen: {nv.hoten}, Luong: {nv.Tinhluong()}\n");
        }

        //tìm nhân viên
        Console.Write("Nhap MSNV: ");
        string ma = Console.ReadLine();
        var tim = dsNhanVien.Find(n => n.msnv == ma);
        if( tim != null)
        {
            Console.WriteLine($"MSNV: {tim.msnv}, HoTen: {tim.hoten}, Luong: {tim.Tinhluong()}");
        }
        else
        {
            Console.WriteLine("Khong tim thay NV theo MSNV");
        }
    }
}
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------

