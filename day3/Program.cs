
//  1.Collection trong C#
//      🔹 1.1. List<T>
//              Danh sách có thứ tự, có thể thêm/xóa phần tử linh hoạt.
//              Truy cập bằng chỉ số.
//List<string> dsten = new List<string>();

//dsten.Add("Toan");
//dsten.Add("Hieu");
//dsten.Add("Nam");

//dsten.Remove("Hieu");

//foreach (var item in dsten)
//{
//    Console.WriteLine($"{item}");
//}
//Console.WriteLine(dsten[1]);
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//      1.2.Dictionary < TKey, TValue >
//              Lưu trữ dữ liệu theo cặp Key – Value.
//              Key phải duy nhất, không trùng.
//Dictionary<String, String> dic = new Dictionary<string, string>();

//dic["VN"] = "Việt Nam";
//dic["JP"] = "Nhật Bản";
//dic["US"] = "Mỹ";


//foreach (var item in dic)
//{
//    Console.WriteLine($"Key: {item.Key} - Value: {item.Value}");
//}

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//      🔹 1.3.HashSet < T >
//              Tập hợp không chứa giá trị trùng lặp.
//              Không đảm bảo thứ tự.
//HashSet<int> num =  new HashSet<int>() { 1,2,3,5,2,};
//num.Add(4);
//num.Add(2);

//foreach (int i in num)
//{
//    Console.WriteLine(i);
//}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//      3.LINQ(Language Integrated Query)
//              LINQ giúp truy vấn dữ liệu trong bộ nhớ (List, Array, Dictionary...) như SQL.
//              🔹 3.1. Toán tử cơ bản
//              where: lọc dữ liệu.
//              select: chọn dữ liệu.
//              order by: sắp xếp.
//              group by: gom nhóm.
//              join: kết hợp nhiều tập dữ liệu.
//public class Program
//{
//    public static void Main()
//    {
//        List<int> listNumber = new List<int>() { 1,2,4,6,19, 20};

//        //where
//        var soChan = listNumber.Where(x => x % 2 == 0);

//        // order by, sắp xếp 
//        var sapXep = listNumber.OrderByDescending(x => x);

//        //select
//        var binhPhuong = listNumber.Select(x =>x * x);

//        Console.WriteLine("Số chắn: " + String.Join(", ", soChan));
//        Console.WriteLine("Sắp xếp: " + String.Join(", ", sapXep));
//        Console.WriteLine("Bình phương: " + String.Join(", ", binhPhuong));
//    }
//}

//                                                     1.Tạo danh sách sản phẩm, lọc giá > 100k
public class SanPham
{
    public string ten { get; set; }
    public string loai { get; set; }
    public decimal gia { get; set; }
}

//public class Program
//{
//    public static void Main()
//    {
//        List<SanPham> dsSanPham = new List<SanPham>
//        {
//            new SanPham{ten="Iphone 17", loai="điện thoại", gia=59000000},
//            new SanPham{ten="Iphone 17 pro max", loai="điện thoại", gia=79000000},
//            new SanPham{ten="Laptop ASUS", loai="máy tính", gia=39000000},
//        };

//        var locDS = dsSanPham.Where(x => x.gia > 50000000);
//        Console.WriteLine("San pham có gia > 50.000.000");
//        foreach (var item in locDS)
//        {
//            Console.WriteLine($"{item.ten} - {item.gia}");
//        }

//    }
//}
//                                                     2. Sắp xếp danh sách sản phẩm theo giá giảm dần
//public class Program
//{
//    public static void Main()
//    {
//        List<SanPham> dsSanPham = new List<SanPham>
//        {
//            new SanPham{ten="Iphone 17", loai="điện thoại", gia=59000000},
//            new SanPham{ten="Iphone 17 pro max", loai="điện thoại", gia=79000000},
//            new SanPham{ten="Laptop ASUS", loai="máy tính", gia=39000000},
//        };

//        var locDS = dsSanPham.OrderByDescending(x => x.gia);
//        Console.WriteLine("San pham có gia giam dan");
//        foreach (var item in locDS)
//        {
//            Console.WriteLine($"{item.ten} - {item.gia}");
//        }

//    }
//}
//                                                     3. Đếm số sản phẩm theo từng loại (group by)
//public class Program
//{
//    public static void Main()
//    {
//        List<SanPham> dsSanPham = new List<SanPham>
//        {
//            new SanPham{ten="Iphone 17", loai="điện thoại", gia=59000000},
//            new SanPham{ten="Iphone 17 pro max", loai="điện thoại", gia=79000000},
//            new SanPham{ten="Laptop ASUS", loai="máy tính", gia=39000000},
//        };

//        var thongke = dsSanPham
//            .GroupBy(sp => sp.loai)
//            .Select(g => new { loai = g.Key, soluong = g.Count() });

//        Console.WriteLine("So luong theo loai: ");

//        foreach (var item in thongke)
//        {
//            Console.WriteLine($"Loai: {item.loai} - so luong: {item.soluong}");
//        }


//        var loaisp = dsSanPham.GroupBy(sp => sp.loai);
//        foreach (var nhom in loaisp)
//        {
//            Console.WriteLine($"San pham loai: {nhom.Key}");
//            foreach (var item in nhom)
//            {
//                Console.WriteLine($"ten: {item.ten} - gia: {item.gia}");
//            }
//        }
//    }
//}
//                                      Trong LINQ, join hoạt động giống như JOIN trong SQL, cho phép kết hợp hai tập dữ liệu dựa trên một khóa chung.
public class NhanVien
{
    public int MsNV { get; set; }
    public string TenNV { get; set; }
    public int MsPB { get; set; }
}

public class PhongBan
{
    public int MsPB { get; set; }
    public string TenPB { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<NhanVien> dsNhanVien = new List<NhanVien>()
        {
            new NhanVien{MsNV=1, TenNV="Toan", MsPB=1},
            new NhanVien{MsNV=2, TenNV="An", MsPB=2},
            new NhanVien{MsNV=3, TenNV="Binh", MsPB=2},
            new NhanVien{MsNV=4, TenNV="Nga", MsPB=2},
            new NhanVien{MsNV=5, TenNV="Teo"},
        };

        List<PhongBan> dsPhongBan = new List<PhongBan>()
        {
            new PhongBan{MsPB = 1, TenPB="Cong nghe thong tin"},
            new PhongBan{MsPB = 2, TenPB = "Ke toan"}
        };

        //var ketqua = from nv in dsNhanVien
        //             join pb in dsPhongBan
        //             on nv.MsPB equals pb.MsPB
        //             select new
        //             {
        //                 nv.TenNV,
        //                 pb.TenPB
        //             };
        //Console.WriteLine("Danh sach nhan vien + phong ban:");
        //foreach (var item in ketqua)
        //{
        //    Console.WriteLine($"{item.TenNV} - {item.TenPB}");
        //}
        //-----------------------------------------------------------------------------
        //var ketqua2 = from nv in dsNhanVien
        //              join pb in dsPhongBan
        //              on nv.MsPB equals pb.MsPB into temp
        //              from pb in temp.DefaultIfEmpty()
        //              select new
        //              {
        //                  nv.TenNV,
        //                  tenPhongBan = pb != null ? pb.TenPB : "Chua co"
        //              };

        //Console.WriteLine("Danh sach NV + PB:");
        //foreach (var item in ketqua2)
        //{
        //    Console.WriteLine($"{item.TenNV} - {item.tenPhongBan}");
        //}
        //-----------------------------------------------------------------------------
        var ketqua3 = from pb in dsPhongBan
                      join nv in dsNhanVien
                      on pb.MsPB equals nv.MsPB into nhomNV
                      select new
                      {
                          pb.TenPB,
                          DanhSachPB = nhomNV

                      };
        Console.WriteLine("Danh sach nhan vien theo phong ban:");
        foreach (var item in ketqua3)
        {
            Console.WriteLine($"Phong ban: {item.TenPB}");
            foreach (var nv in item.DanhSachPB)
            {
                Console.WriteLine($" - {nv.TenNV}");
            }
        }
        //-----------------------------------------------------------------------------

    }

}