//1. Tính đóng gói: Là việc gom dữ liệu (thuộc tính) và các hành vi (phương thức) xử lý dữ liệu đó vào cùng một đơn vị (gọi là lớp - Class),
//                  đồng thời che giấu dữ liệu nội bộ và chỉ cho phép truy cập thông qua các phương thức công khai (Public Methods).

//VD: Một đối tượng XeHoi có thuộc tính tocDo (tốc độ). Thay vì cho phép truy cập và thay đổi trực tiếp xe.tocDo = -100,
//      ta dùng phương thức public void TangToc(int luong) để kiểm tra và chỉ cho phép tốc độ tăng lên giá trị hợp lệ. Dữ liệu được bảo vệ.
//------------------------------------------------------------------------------------------------------------------------------------------------


//2. Tính kế thừa: Là khả năng tạo ra một lớp mới (lớp con - Subclass) dựa trên một lớp đã tồn tại (lớp cha - Superclass).

//VD: Lớp Cha HinhHoc có phương thức TinhDienTich(). Lớp Con HinhChuNhat kế thừa từ HinhHoc và có thể sử dụng
//      hoặc ghi đè phương thức TinhDienTich() để tính diện tích hình chữ nhật.
//------------------------------------------------------------------------------------------------------------------------------------------------


//3. Tính đa hình: Là khả năng của các đối tượng thuộc các lớp khác nhau có thể được xử lý thông qua cùng một giao diện chung.

//VD: Một phương thức public void Ve(HinhHoc hinh) có thể nhận đối tượng của bất kỳ lớp con nào của HinhHoc như HinhChuNhat, HinhTron,
//------------------------------------------------------------------------------------------------------------------------------------------------


//4. Tính trừu tượng: Là việc ẩn đi các chi tiết phức tạp và chỉ hiển thị những phần quan trọng của đối tượng.

//VD: Lớp trừu tượng HinhHoc có phương thức trừu tượng TinhDienTich() mà không cần biết cách tính diện tích cụ thể của từng hình học.
//------------------------------------------------------------------------------------------------------------------------------------------------





//---------------------------------Tính đóng gói(Encapsulation)-----------------------------------------------------
public class TaiKhoanNganHang
{
    private decimal soDu;

    //thuộc tính số dư
    public decimal soDuHienTai
    {
        get { return soDu; }
    }
    //phương thức
    public void NapTien(decimal luong)
    {
        if(luong > 0)
        {
            soDu += luong;
            Console.WriteLine($"Nạp {luong} thành công. Số dư hiện tại: {soDu}");
        }
        else
        {
            Console.WriteLine("Số tiền nạp phải lớn hơn 0.");
        }
    }
}

//---------------------------------Tính kế thừa(Inheritance)--------------------------------------------------------
public class NhanVien
{
    public string Ten { get; set; }
    public void LamViec()
    {
        Console.WriteLine($"{Ten} đang làm việc.");
    }
}
public class KySu : NhanVien 
{
    public string ChuyenNganh { get; set; }
    public void ThietKe()
    {
        Console.WriteLine($"{Ten} đang làm việc trong chuyên ngành {ChuyenNganh}");
    }
}
//---------------------------------Tính đa hình(Polymorphism)-------------------------------------------------------
public class DongVat
{
    public virtual void Keu()
    {
        Console.WriteLine("Động vật kêu");
    }
}
public class Cho : DongVat
{
    public override void Keu()
    {
        Console.WriteLine("Chó sủa: Gâu Gâu");
    }
}
//---------------------------------Tính trừu tượng(Abstraction)-----------------------------------------------------
public interface IDieuKien
{
    void BatTatMayLanh();
}
public class MayLanh : IDieuKien
{
    private bool trangThai = false;
    public void BatTatMayLanh()
    {
        trangThai = !trangThai;
        string trangThaiStr = trangThai ? "Bật" : "Tắt";
        Console.WriteLine($"Máy lạnh đang trong trạng thái {trangThaiStr}");
    }
}


public class Test_OOP
{
    //public static void Main(string[] args)
    //{
    //    Console.OutputEncoding = System.Text.Encoding.UTF8;
    //    //--------------------Tính đóng gói------------------------------
    //    //TaiKhoanNganHang tk = new TaiKhoanNganHang();
    //    //tk.NapTien(-1000000);

    //    //--------------------Tính kế thừa------------------------------
    //    //NhanVien nv = new NhanVien();
    //    //nv.Ten = "Nguyễn Văn A";
    //    //nv.LamViec();

    //    //KySu ks = new KySu();
    //    //ks.Ten = "Trần Thị B";
    //    //ks.ChuyenNganh = "Công nghệ thông tin";
    //    //ks.ThietKe();
    //    //--------------------Tính đa hình------------------------------
    //    //DongVat dv = new DongVat();
    //    //dv.Keu();

    //    //Cho c = new Cho();
    //    //c.Keu();
    //    //--------------------Tính trừu tượng------------------------------
    //    //MayLanh ml = new MayLanh();
    //    //ml.BatTatMayLanh();
    //    //-----------------------------------------------------------------
    //    //bool b;
    //    //b = true;

    //    //Console.WriteLine("Before assignment");
    //    //Console.WriteLine(b);

    //    //Console.WriteLine("Enter true or false: ");

    //    //while (true)
    //    //{
    //    //    string input = Console.ReadLine();
    //    //    if (bool.TryParse(input, out b))
    //    //    {
    //    //        break;
    //    //    }
    //    //    Console.WriteLine("Invalid input. Please enter true or false: ");
    //    //}
    //    //Console.WriteLine("After assignment");
    //    //Console.WriteLine(b);
    //    //-----------------------------------------------------------------

    //    //Console.WriteLine("Nhập j: ");
    //    //int j = int.Parse(Console.ReadLine());
    //    //Console.WriteLine("Giá trị j:",+j);

    //    int i = 10;
    //    short s = 100;
    //    long l = 10000L;
    //    uint ui = 12;

    //    int intNum = (int)l;
    //    short shortNum = (short)i;
    //    Console.WriteLine(intNum);
    //    Console.WriteLine(shortNum);
    //    Console.WriteLine(ui);
    //    Console.WriteLine(l);
    //    Console.WriteLine(s);
    //    Console.WriteLine(i);



    //}
}