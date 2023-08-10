namespace Program
{
    class Program
    {
        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1, out TResult>(T1 args1);
        delegate TResult Func2<in T1, in T2, out TResult>(T1 args1, T2 args2);
        delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 args1, T2 args2, T3 args);

        static void Main(string[] args)
        {
            //*********Func
            //
            // Func<int, int, int> calc = (a, b) => a + b;
            // int result = calc(2, 1);
            //
            // Console.WriteLine($"Result : {result}");

            // float a = 10.4f,
            //     b = 13.4f;
            // int c = 32;
            //
            // Func<float, float, int, float> calc2 = (a, b, c) => (a + b) * c;
            //
            // float result = calc2(a, b, c);

            Func<decimal, decimal, decimal> calculateTotalAnnualSalary = (
                annualSalary,
                bonusPercentage
            ) => annualSalary + (annualSalary * (bonusPercentage / 100));

            decimal result = calculateTotalAnnualSalary(30_800_000m, 20.5m);

            Console.WriteLine($"Result : {result}");
        }
    }
}
