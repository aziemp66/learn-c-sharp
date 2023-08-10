namespace Program
{
    static class Extensions
    {
        public static List<Employee> FilterEmployee(
            this List<Employee> employees,
            Predicate<Employee> predicate
        )
        {
            List<Employee> FilteredEmployee = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    FilteredEmployee.Add(employee);
                }
            }

            return FilteredEmployee;
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }
    }

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

            // Console.WriteLine($"Result : {result}");

            //*********Action
            Action<int, string, string, decimal, char, bool> displayEmployeeDetails = (
                args1,
                args2,
                args3,
                args4,
                args5,
                args6
            ) =>
                Console.Write(
                    $"Id : {args1}\nFirst Name : {args2}\nLast Name : {args3}\nAnnual Salary : {args4}\nGender : {args5}\nIs Manager : {args6}\n"
                );

            // displayEmployeeDetails(123, "Azie", "Melza Pratama", 750_000_000m, 'm', true);

            //************Predicate
            List<Employee> employees = new List<Employee>();
            employees.Add(
                new Employee
                {
                    Id = 1,
                    FirstName = "Azie",
                    LastName = "Melza Pratama",
                    AnnualSalary = 750_000_000m,
                    Gender = 'm',
                    IsManager = true
                }
            );
            employees.Add(
                new Employee
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    AnnualSalary = 500_000_000m,
                    Gender = 'm',
                    IsManager = false
                }
            );
            employees.Add(
                new Employee
                {
                    Id = 3,
                    FirstName = "Mei",
                    LastName = "Suzuka",
                    AnnualSalary = 650_000_000m,
                    Gender = 'f',
                    IsManager = true
                }
            );
            employees.Add(
                new Employee
                {
                    Id = 4,
                    FirstName = "Tiffany",
                    LastName = "Smith",
                    AnnualSalary = 480_000_000m,
                    Gender = 'f',
                    IsManager = false
                }
            );

            // //Filter Employee : Find Only Male Employee
            // List<Employee> maleEmployeesFiltered = Extensions.FilterEmployee(
            //     employees,
            //     e => e.Gender == 'm'
            // );
            //
            // Console.WriteLine("All Male Employees");
            // foreach (var item in maleEmployeesFiltered)
            // {
            //     displayEmployeeDetails(
            //         item.Id,
            //         item.FirstName,
            //         item.LastName,
            //         item.AnnualSalary,
            //         item.Gender,
            //         item.IsManager
            //     );
            //     Console.WriteLine();
            // }
            //
            // List<Employee> moreThan500MSalaryEmployees = Extensions.FilterEmployee(
            //     employees,
            //     e => e.AnnualSalary > 500_000_000m
            // );
            //
            // Console.WriteLine("All Employees who made more than 500 Mil");
            // foreach (var item in moreThan500MSalaryEmployees)
            // {
            //     displayEmployeeDetails(
            //         item.Id,
            //         item.FirstName,
            //         item.LastName,
            //         item.AnnualSalary,
            //         item.Gender,
            //         item.IsManager
            //     );
            //     Console.WriteLine();
            // }

            // List<Employee> employeesFiltered = employees.FilterEmployee(e => e.IsManager == true);
            // foreach (var item in employeesFiltered)
            // {
            //     displayEmployeeDetails(
            //         item.Id,
            //         item.FirstName,
            //         item.LastName,
            //         item.AnnualSalary,
            //         item.Gender,
            //         item.IsManager
            //     );
            //     Console.WriteLine();
            // }

            List<Employee> employeesFiltered = employees
                .Where(e => e.AnnualSalary > 500_000_000m)
                .ToList();
            foreach (var item in employeesFiltered)
            {
                displayEmployeeDetails(
                    item.Id,
                    item.FirstName,
                    item.LastName,
                    item.AnnualSalary,
                    item.Gender,
                    item.IsManager
                );
                Console.WriteLine();
            }
        }
    }
}
