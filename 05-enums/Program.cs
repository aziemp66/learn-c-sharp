namespace Enums
{
    enum Month
    {
        Jan = 1,
        Feb = 2,
        Mar = 4,
        Apr = 8,
        May = 16,
        Jun = 32,
        Jul = 64,
        Aug = 128,
        Sep = 256,
        Oct = 512,
        Nov = 1024,
        Dec = 2048
    }

    class Program
    {
        public static void ProcessMonthlyExpenditure(Month month)
        {
            switch (month)
            {
                case Month.Jan:
                    Console.WriteLine("Processing data for Jan...");
                    Console.WriteLine($"The value of month is {(int)month}");
                    break;
                case Month.Feb:
                    Console.WriteLine("Processing data for Feb...");
                    break;
                case Month.Mar:
                    Console.WriteLine("Processing data for Mar...");
                    break;
                case Month.Apr:
                    Console.WriteLine("Processing data for Apr...");
                    break;
                case Month.May:
                    Console.WriteLine("Processing data for May...");
                    break;
                case Month.Jun:
                    Console.WriteLine("Processing data for Jun...");
                    break;
                case Month.Jul:
                    Console.WriteLine("Processing data for Jul...");
                    break;
                case Month.Aug:
                    Console.WriteLine("Processing data for Aug...");
                    Console.WriteLine($"The value of month is {(int)month}");
                    break;
                case Month.Sep:
                    Console.WriteLine("Processing data for Sep...");
                    break;
                case Month.Oct:
                    Console.WriteLine("Processing data for Oct...");
                    break;
                case Month.Nov:
                    Console.WriteLine("Processing data for Nov...");
                    break;
                case Month.Dec:
                    Console.WriteLine("Processing data for Dec...");
                    break;
                default:
                    throw new Exception("Invalid Month");
            }
        }

        // public static void PopulateMonthlyExpenditure(decimal[] data)
        // {
        //     if (data.Length != 12)
        //     {
        //         throw new RankException("Array's Lenght must be 12");
        //     }
        //     data[0] = 5000m;
        //     data[1] = 3000.50m;
        //     data[2] = 4000.3m;
        //     data[3] = 2000m;
        //     data[4] = 3500m;
        //     data[5] = 4000.2m;
        //     data[6] = 1000m;
        //     data[7] = 500m;
        //     data[8] = 600m;
        //     data[9] = 6000m;
        //     data[10] = 3000m;
        //     data[11] = 10000m;
        // }
        //
        // public static void CountBits(int value)
        // {
        //     // Brian Kernighans Algorithm
        //
        //     int count = 0;
        //
        //     while (value != 0)
        //     {
        //         count++;
        //         value &= value - 1;
        //     }
        // }

        static void Main(string[] args)
        {
            var data = new decimal[12];

            ProcessMonthlyExpenditure(Month.Jan);
            ProcessMonthlyExpenditure(Month.Aug);

            Console.ReadKey();
        }
    }
}
