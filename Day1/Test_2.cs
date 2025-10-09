using System;
using System.Data;

public class ConstantsDemo
{

    // 1. CONST: Phải là hằng số biên dịch và được gán giá trị ngay lập tức.

    // Hợp lệ: Giá trị được biết tại thời gian biên dịch
    public const int DaysInWeek = 7;
    public const string DefaultGreeting = "Hello World";

    // KHÔNG HỢP LỆ: Giá trị không phải hằng số biên dịch
    // public const int CurrentHour = DateTime.Now.Hour; // --> LỖI BIÊN DỊCH

    // 2. READONLY: Giá trị có thể được gán trong Constructor (thời gian chạy).

    public readonly int UserId;
    public readonly DateTime StartTime; // Giá trị này phụ thuộc vào thời điểm tạo đối tượng.
    public readonly List<string> Items; // Có thể áp dụng cho Reference Type.

    // Phương thức khởi tạo (Constructor)
    public ConstantsDemo(int id)
    {
        // Có thể gán giá trị cho readonly tại đây.
        UserId = id;
        StartTime = DateTime.Now;
        Items = new List<string> { $"User-{id}" };

        // KHÔNG THỂ gán lại const
        // DaysInWeek = 8; // --> LỖI BIÊN DỊCH

        // KHÔNG THỂ gán lại readonly sau khi constructor kết thúc.
    }

    public void ShowValues()
    {
        Console.WriteLine($"[CONST] DaysInWeek: {DaysInWeek} (Chung cho mọi đối tượng)");
        Console.WriteLine($"[READONLY] UserId: {UserId} (Khác biệt theo từng đối tượng)");
        Console.WriteLine($"[READONLY] StartTime: {StartTime:HH:mm:ss}");

        // Vấn đề của readonly với Reference Type:
        // Bạn không thể gán lại đối tượng List mới:
        // Items = new List<string>(); // --> LỖI BIÊN DỊCH

        // NHƯNG bạn có thể thay đổi NỘI DUNG của đối tượng:
        Items.Add("New Item");
        Console.WriteLine($"[READONLY List] Số lượng Items: {Items.Count} (Đã thay đổi nội dung!)");
    }
}


//check
public class CheckNumberDemo
{
    //kiểm tra số nguyên tố
    public static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n ==2) return true;
        if (n % 2 == 0) return false;
        int sqrt = (int)Math.Sqrt(n);
        for (int i = 3;i<= sqrt; i += 2)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    //kiểm tra số chính phương
    public static bool IsPerfectSquare(int n)
    {
        if (n < 0) return false;
        int sqrt = (int)Math.Sqrt(n);
        return (sqrt * sqrt == n);
    }

    //kiểm tra số hoàn hảo
    public static bool IsPerfectNumber(int n)
    {
        if (n < 2) return false;
        int sum = 1;
        int sqrt = (int)Math.Sqrt(n);
        for(int i = 2; i < sqrt; i++)
        {
            if (n % i == 0)
            {
                sum += i;
                int other = n / i;
                if (other != i) sum += other;
            }
        }
        return sum == n;
    }
    
}

//tìm ƯC, BC, WCLN, BCNN
public class MathDemo
{
    // ƯC của 2 số
    public static List<int> ListCD(int a, int b)
    {
        List<int> result = new List<int>();
        int min = Math.Min(Math.Abs(a), Math.Abs(b));
        for(int i = 1; i <= min; i++)
        {
            if(a%i==0 && b % i == 0)
            {
                result.Add(i);
            }
        }
        return result;
    }
    //BC của 2 số
    public static List<int> ListCM(int a, int b, int count=10)
    {
        List<int> result = new List<int>();
        int lcm = LCM(a, b);
        for(int i=1; i <= count; i++)
        {
            result.Add(lcm * i);
        }
        return result;
    }
    //BCNN
    public static int LCM(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        if(a == 0 || b == 0) return 0;
        return (a / GCD(a, b)) * b;
    }
    //ƯCLN
    public static int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //Console.WriteLine("--- TẠO ĐỐI TƯỢNG 1 ---");
        //ConstantsDemo demo1 = new ConstantsDemo(101);
        //demo1.ShowValues();

        //Thread.Sleep(500); // Tạm dừng 0.5 giây để thấy sự khác biệt về thời gian

        //Console.WriteLine("\n--- TẠO ĐỐI TƯỢNG 2 ---");
        //ConstantsDemo demo2 = new ConstantsDemo(202);
        //demo2.ShowValues();

        //Console.WriteLine("\n--- SO SÁNH CUỐI CÙNG ---");
        //Console.WriteLine($"demo1.UserId: {demo1.UserId}");
        //Console.WriteLine($"demo2.UserId: {demo2.UserId} (Readonly khác nhau)");
        //Console.WriteLine($"demo1.StartTime: {demo1.StartTime:HH:mm:ss}");
        //Console.WriteLine($"demo2.StartTime: {demo2.StartTime:HH:mm:ss} (Readonly khác nhau)");
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //char ch;

        //Console.WriteLine("Enter your favourite subject option: ");
        //ch = (char)Console.Read();

        //if (ch == 'e')
        //{
        //    Console.WriteLine("Favourite subject is English");
        //}
        //else if (ch == 'm')
        //{
        //    Console.WriteLine("Favourite subject is Maths");
        //}
        //else if (ch == 's')
        //{
        //    Console.WriteLine("Favourite subject is Science");
        //}
        //else
        //{
        //    Console.WriteLine("Other options than my favourite!");
        //}

        //Console.WriteLine("End of the program");
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        //int i = 0;
        //int count = 0;

        //// Read the input and store in a variable 'i'
        //string input = Console.ReadLine();
        //i = int.Parse(input);

        //// Loop through each time dividing by 10 to count the digits. 
        //do
        //{
        //    count++;
        //    i = i / 10;
        //} while (i > 0);

        //// Print to the console output
        //Console.WriteLine(count);

        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //int a ;
        //int result = 1;

        //string input = Console.ReadLine();
        //a = int.Parse(input);

        //do
        //{
        //    result = result * a;
        //    a--;
        //}
        //while (a > 0);

        //Console.WriteLine(result);
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //string[] array = new string[] {"heloo", "50", "hi", "100", "200", "abc" };
        //int value;

        //for(int i =0; i < array.Length; i++)
        //{
        //    if (int.TryParse(array[i], out value)){
        //        Console.WriteLine(value);
        //    }
        //}
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        //string[] array = new string[]
        //{
        //    "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        //};
        //Console.WriteLine(array.Length);
        //Console.WriteLine(array[3]);
        //foreach (var item in array)
        //{
        //    Console.WriteLine(item);
        //}
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //Console.WriteLine("----------MENU----------");
        //Console.WriteLine("1. for");
        //Console.WriteLine("2. foreach");
        //Console.WriteLine("3. while");
        //Console.WriteLine("4. do - while");
        //Console.WriteLine("0. Thoát");


        //int choice;
        //do
        //{
        //    Console.WriteLine("Nhập lựa chọn: ");
        //    choice = int.Parse(Console.ReadLine());

        //    switch (choice)
        //    {
        //        case 1:
        //            Console.WriteLine("Vòng lặp for");
        //            int a = 5;
        //            for (int i = 0; i < a; i++)
        //            {
        //                Console.WriteLine("i =" + i);
        //            }
        //            break;
        //        case 2:
        //            Console.WriteLine("Vòng lặp foreach");
        //            List<string> list = new List<string>() { "C#", "Java", "Python", "JavaScript" };
        //            foreach (var item in list)
        //            {
        //                Console.WriteLine(item);
        //            }
        //            break;
        //        case 3:
        //            Console.WriteLine("Vòng lặp while");
        //            int b = 0;
        //            while (b < 4)
        //            {
        //                Console.WriteLine($"Vòng lặp chạy lần thứ {b}");
        //                b++;
        //            }
        //            break;
        //        case 4:
        //            Console.WriteLine("Vòng lặp do-while");
        //            string choice2;
        //            do
        //            {
        //                Console.WriteLine("Bạn có muốn tiếp tục (y/n): ");
        //                choice2 = Console.ReadLine()?.ToLower();
        //            }
        //            while (choice2 != "y" && choice2 != "n");
        //            break;
        //        default:
        //            Console.WriteLine("Lựa chọn khác 1");
        //            break;
        //    }
        //}
        //while (choice !=0);
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //Hình chữ nhật
        //int i, j;
        //Console.WriteLine("Enter the number of rows: ");
        //i = int.Parse(Console.ReadLine());
        //Console.WriteLine("Enter the number of columns: ");
        //j = int.Parse(Console.ReadLine());
        //for(int row = 0; row < i; row++)
        //{
        //    for(int col = 0; col < j; col++)
        //    {
        //        Console.Write("* ");
        //    }
        //    Console.WriteLine();
        //}

        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //Hình tam giác vuông

        //int i;
        //i = int.Parse(Console.ReadLine());
        //for(int row = 0; row < i; row++)
        //{
        //    for(int col =0; col <= row; col++)
        //    {
        //        Console.Write("* ");
        //    }
        //    Console.WriteLine();
        //}

        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //Tam giác cân
        //int i;
        //Console.WriteLine("Enter the number of rows: ");
        //i = int.Parse(Console.ReadLine());

        //for(int row = 0; row<i; row++)
        //{
        //    for(int space=0; space < i - row - 1; space++)
        //    {
        //        Console.Write(" ");
        //    }
        //    for(int star =0; star <= row; star++)
        //    {
        //        Console.Write("* ");
        //    }
        //    Console.WriteLine();
        //}
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //hình vuông đặc
        //int i;
        //Console.WriteLine("Nhập i: ");
        //i = int.Parse(Console.ReadLine());
        //for(int row = 0; row < i; row++)
        //{
        //    for(int col = 0; col < i; col++)
        //    {
        //        Console.Write("* ");
        //    }
        //    Console.WriteLine();
        //}
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //hình vuông rỗng
        //int i;
        //Console.WriteLine("Nhập i: ");
        //i = int.Parse(Console.ReadLine());
        //for (int row = 0; row < i; row++)
        //{
        //    for (int col = 0; col < i; col++)
        //    {
        //        if (row == 0 || row == i - 1 || col == 0 || col == i - 1)
        //        {
        //            Console.Write("* ");
        //        }
        //        else
        //        {
        //            Console.Write("  ");
        //        }
        //    }
        //    Console.WriteLine();
        //}
        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        //ma trận vuông random
        //int n;
        //Console.WriteLine("Nhập n: ");
        //n = int.Parse(Console.ReadLine());
        //int[,] maxtri = new int[n, n];
        //Random random = new Random();
        //for (int row = 0; row < n; row++)
        //{
        //    for (int col = 0; col < n; col++)
        //    {
        //        maxtri[row, col] = random.Next(1, 100);
        //        Console.Write(maxtri[row, col] + "\t");
        //    }
        //    Console.WriteLine();
        //}
        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        Console.WriteLine("-----------------MENU-----------------");
        Console.WriteLine("1.  Tạo ma trận vuông NxN");
        Console.WriteLine("2.  Tìm số MAX");
        Console.WriteLine("3.  Tìm số MIN");
        Console.WriteLine("4.  Tìm số nguyên tố");
        Console.WriteLine("5.  Tính tổng mảng");
        Console.WriteLine("6.  Tìm MAX trên cột bất kỳ");
        Console.WriteLine("7.  Tính tổng biên");
        Console.WriteLine("8.  Tính tổng đường chéo chính");
        Console.WriteLine("9.  Tính tổng đường chéo phụ");
        Console.WriteLine("10. Tìm tam giác trên");
        Console.WriteLine("11. Tìm số chính phương");
        Console.WriteLine("12. Tìm số hoàn hảo");
        Console.WriteLine("13. kiểm tra số chẵn lẻ tại vị trí NxN");
        Console.WriteLine("14. Tìm ước tại vị trí NxN");
        Console.WriteLine("15. Tìm ƯLN tại vị trí NxN");
        Console.WriteLine("16. Tìm BC của 2 số bất kì");
        Console.WriteLine("17. Tìm ƯC của 2 số bất kì");
        Console.WriteLine("18. Tìm ƯCLN của 2 số bất kì");
        Console.WriteLine("19. Tìm BCNN của 2 số bất kì");

        Console.WriteLine("0.  Thoát");
        int choice = -1;
        int n = 0;
        int[,] maxtri = null;
        
        while(true){
            Console.WriteLine("Nhập lựa chọn: ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out choice))
            {
                Console.WriteLine("❌ Vui lòng nhập số hợp lệ!");
                continue;
            }

            if (choice ==0)
            {
                Console.WriteLine("Kết thúc chương trình");
                return;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Nhập n: ");
                    n = int.Parse(Console.ReadLine());
                    maxtri = new int[n, n];
                    Random random = new Random();
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            maxtri[row, col] = random.Next(1, 50);
                            Console.Write(maxtri[row, col] + "\t");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    if(maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    int max = maxtri[0, 0];
                    for(int row =0; row < maxtri.GetLength(0); row++)
                    {
                        for(int col =0; col < maxtri.GetLength(1); col++)
                        {
                            if(maxtri[row, col] > max)
                            {
                                max = maxtri[row, col];
                            }
                        }
                    }
                    Console.WriteLine("Số MAX trong ma trận là: "+max);
                    break;
                case 3:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    int min = maxtri[0, 0];
                    for (int row=0;row<maxtri.GetLength(0);row++)
                    {
                        for (int col=0;col<maxtri.GetLength(1);col++)
                        {
                            if (maxtri[row,col] < min)
                            {
                                min = maxtri[row, col];
                            }

                        }
                    }
                    Console.WriteLine("Số MIN trong ma trận là: " + min);
                    break;
                case 4:
                    if (maxtri ==null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    Console.WriteLine("Các số nguyên tố trong ma trận: ");
                    for(int row = 0; row < maxtri.GetLength(0); row++)
                    {
                        for(int col = 0; col < maxtri.GetLength(1); col++)
                        {
                            if (CheckNumberDemo.IsPrime(maxtri[row, col]))
                            {
                                Console.Write(maxtri[row, col]+"\t");
                            }
                        }
                    }
                    Console.WriteLine();
                    break;
                case 5:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    int sum = 0;
                    for(int row = 0; row < maxtri.GetLength(0); row++)
                    {
                        for(int col = 0; col < maxtri.GetLength(1); col++)
                        {
                            sum += maxtri[row, col];
                        }
                    }
                    Console.WriteLine("Tổng các phần tử trong ma trận là: "+sum);
                    break;
                case 6:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    int colIndexMax;
                    while (true)
                    {

                        Console.WriteLine("Nhập cột cần tìm MAX (0 đến " + (n - 1) + "):");
                        string colInput= Console.ReadLine();
                        if (!int.TryParse(colInput, out colIndexMax) || colIndexMax<0|| colIndexMax>=n)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    int maxCol = maxtri[0, colIndexMax];
                    for (int row = 0; row < maxtri.GetLength(0); row++)
                    {
                        if(maxtri[row, colIndexMax] > maxCol)
                        {
                            maxCol = maxtri[row, colIndexMax];
                        }
                    }
                    Console.WriteLine("Số MAX trên cột "+colIndexMax+" là: "+maxCol);

                    break;
                case 7:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    int sumBorder = 0;
                    for(int row = 0; row < maxtri.GetLength(0); row++)
                    {
                        for(int col=0;col<maxtri.GetLength(1); col++)
                        {
                            if(row==0|| row == n - 1 || col == 0 || col == n - 1)
                            {
                                sumBorder += maxtri[row, col];
                            }
                        }
                    }
                    Console.WriteLine("Tổng biên của ma trận là: "+sumBorder);
                    break;
                case 8:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    int sumDiagonal = 0;
                    for(int i2 = 0; i2 < n; i2++)
                    {
                        sumDiagonal += maxtri[i2, i2];
                    }
                    Console.WriteLine("Tổng đường chéo chính là: "+sumDiagonal);
                    break;
                case 9:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    int sumDiagonal2 = 0;
                    for(int i3 = 0; i3 < n; i3++)
                    {
                        sumDiagonal2 += maxtri[i3, n - 1 - i3];
                    }
                    Console.WriteLine("Tổng đường chéo phụ là: " + sumDiagonal2);
                    break;
                case 10:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    Console.WriteLine("Tam giác trên của ma trận là: ");
                    for (int row = 0; row < n; row++)
                    {
                        for(int col = 0; col < n; col++)
                        {
                            if (row<=col)
                            {
                                Console.Write(maxtri[row, col] + " \t");
                            }
                            else
                            {
                                Console.Write(" "+"\t");
                            }
                        }
                        Console.WriteLine();

                    }

                    break;
                case 11:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    Console.WriteLine("Các số chính phương trong ma trận là: ");
                    for(int row = 0; row < maxtri.GetLength(0); row++)
                    {
                        for(int col = 0; col < maxtri.GetLength(1); col++)
                        {
                            if (CheckNumberDemo.IsPerfectSquare(maxtri[row, col]))
                            {
                                Console.Write(maxtri[row, col] + "\t");
                            }
                        }
                    }
                    Console.WriteLine();
                    break;
                case 12:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    Console.WriteLine("Các số hoàn hảo trong ma trận là: ");
                    for (int row = 0; row < maxtri.GetLength(0); row++)
                    {
                        for (int col = 0; col < maxtri.GetLength(1); col++)
                        {
                            if (CheckNumberDemo.IsPerfectNumber(maxtri[row, col]))
                            {
                                Console.Write(maxtri[row, col] + "\t");
                            }
                        }
                    }
                    Console.WriteLine();
                    break;
                case 13:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }
                    
                    int colIndex, rowIndex;
                    while (true)
                    {
                        Console.WriteLine("Nhập hàng (0 đến " + (n - 1) + "):");
                        string rowInputType = Console.ReadLine();
                        if(!int.TryParse(rowInputType, out rowIndex) || rowIndex < 0 || rowIndex >= n)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Nhập cột (0 đến " + (n - 1) + "):");
                        string colInputType = Console.ReadLine();
                        if (!int.TryParse(colInputType, out colIndex) || colIndex < 0 || colIndex >= n)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }

                    int value = maxtri[rowIndex, colIndex];
                    Console.WriteLine(value%2==0? " "+(value)+" là số chẵn": " "+(value)+" là số lẻ");
                    break;
                case 14:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }

                    int colIndex2, rowIndex2;
                    while (true)
                    {
                        Console.WriteLine("Nhập hàng (0 đến " + (n - 1) + "):");
                        string rowInputType = Console.ReadLine();
                        if (!int.TryParse(rowInputType, out rowIndex2) || rowIndex2 < 0 || rowIndex2 >= n)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Nhập cột (0 đến " + (n - 1) + "):");
                        string colInputType = Console.ReadLine();
                        if (!int.TryParse(colInputType, out colIndex2) || colIndex2 < 0 || colIndex2 >= n)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    int value2 = maxtri[rowIndex2, colIndex2];
                    Console.WriteLine("Ước của "+value2+" là: ");
                    for (int i=1; i <= value2; i++)
                    {
                        if (value2 % i == 0)
                        {
                            Console.Write(i + "\t");
                        }
                    }
                    Console.WriteLine();
                    break;
                case 15:
                    if (maxtri == null)
                    {
                        Console.WriteLine("Vui lòng tạo ma trận trước (Chọn 1)");
                        break;
                    }

                    int colIndex3, rowIndex3;
                    while (true)
                    {
                        Console.WriteLine("Nhập hàng (0 đến " + (n - 1) + "):");
                        string rowInputType = Console.ReadLine();
                        if (!int.TryParse(rowInputType, out rowIndex3) || rowIndex3 < 0 || rowIndex3 >= n)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Nhập cột (0 đến " + (n - 1) + "):");
                        string colInputType = Console.ReadLine();
                        if (!int.TryParse(colInputType, out colIndex3) || colIndex3 < 0 || colIndex3 >= n)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    int values3 = maxtri[rowIndex3, colIndex3];
                    int maxUCLN = 0;
                    for(int i = 1; i <= values3; i++)
                    {
                        if (values3 % i == 0)
                        {
                            maxUCLN = Math.Max(maxUCLN, i);
                            
                        }
                    }
                    Console.WriteLine("Ước lớn nhất của " + values3 + " là: "+maxUCLN);
                    break;
                case 16:
                    int a, b;
                    while (true)
                    {
                        Console.WriteLine("Nhập số a: ");
                        string inputa = Console.ReadLine();
                        if(!int.TryParse(inputa, out a) || a <= 0)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Nhập số b: ");
                        string inputb = Console.ReadLine();
                        if (!int.TryParse(inputb, out b) || b <= 0)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    Console.WriteLine("Bội chung của "+a+" và "+b+"(10 số đầu tiên) là: ");
                    foreach (var item in MathDemo.ListCM(a,b,10))
                    {
                        Console.Write(item + "\t");
                    }
                    Console.WriteLine();

                    break;
                case 17:
                    int a1, b1;
                    while (true)
                    {
                        Console.WriteLine("Nhập số a: ");
                        string inputa = Console.ReadLine();
                        if (!int.TryParse(inputa, out a1) || a1 <= 0)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Nhập số b: ");
                        string inputb = Console.ReadLine();
                        if (!int.TryParse(inputb, out b1) || b1 <= 0)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    Console.WriteLine("Ước chung của " + a1 + " và " + b1 + " là: ");
                    foreach (var item in MathDemo.ListCD(a1, b1))
                    {
                        Console.Write(item + "\t");
                    }
                    Console.WriteLine();
                    break;
                case 18:
                    int a2, b2;
                    while (true)
                    {
                        Console.WriteLine("Nhập số a: ");
                        string inputa = Console.ReadLine();
                        if (!int.TryParse(inputa, out a2) || a2 <= 0)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Nhập số b: ");
                        string inputb = Console.ReadLine();
                        if (!int.TryParse(inputb, out b2) || b2 <= 0)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    int ucln = MathDemo.GCD(a2, b2);
                    Console.WriteLine("ƯCLN của " + a2 + " và " + b2 + " là: "+ucln+"");

                    break;
                case 19:
                    int a3, b3;
                    while (true)
                    {
                        Console.WriteLine("Nhập số a: ");
                        string inputa = Console.ReadLine();
                        if (!int.TryParse(inputa, out a3) || a3 <= 0)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Nhập số b: ");
                        string inputb = Console.ReadLine();
                        if (!int.TryParse(inputb, out b3) || b3 <= 0)
                        {
                            Console.WriteLine("Vui lòng nhập lại");
                            continue;
                        }
                        break;
                    }
                    int bcnn = MathDemo.LCM(a3, b3);
                    Console.WriteLine("BCNN của " + a3 + " và " + b3 + " là: " + bcnn + "");
                    break;

                    default:
                    Console.WriteLine("❌ Vui lòng nhập số hợp lệ!");
                    break;
            }
        }
        
    }
}