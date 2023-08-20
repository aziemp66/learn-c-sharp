namespace LinqOperators;

using System.Globalization;
using System.Linq;
using TCPData;

public class Program
{
    static void Main(string[] args)
    {
        var employeeList = Dummy.GetEmployees();
        var departmentList = Data.GetDepartments();

        // OrderByMethodSyntax(employeeList,departmentList);
        // OrderByQuerySyntax(employeeList, departmentList);

        // ThenByMethodSyntax(employeeList, departmentList);
        // ThenByQuerySyntax(employeeList, departmentList);

        // GroupByMethodSyntax(employeeList, departmentList);
        // GroupByQuerySyntax(employeeList, departmentList);

        // ToLookUpMethodSyntax(employeeList, departmentList);
        // ToLookUpQuerySyntax(employeeList,departmentList);

        // SelectManyMethodSyntax(employeeList, departmentList);
        // SelectManyQuerySyntax(employeeList, departmentList);

        // Distinct();
        // DistinctBy(employeeList, departmentList);

        // All();
        // Any();
        // Contains();

        // First(employeeList, departmentList);
        // FirstOrDefault(employeeList, departmentList);
        // Last(employeeList, departmentList);
        // LastOrDefault(employeeList, departmentList);
        // Single(employeeList, departmentList);
        // SingleOrDefault(employeeList, departmentList);

        // Except();
        // ExceptBy();

        Intersect();
        IntersectBy();
    }

    static void OrderByMethodSyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        var results = employeeList
            .Join(
                departmentList,
                (e) => e.DepartmentId,
                (d) => d.Id,
                (emp, dept) =>
                    new
                    {
                        Id = emp.Id,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        AnnualSalary = emp.AnnualSalary,
                        DepartmentID = dept.Id,
                        DepartmentName = dept.LongName
                    }
            )
            .OrderBy(i => i.DepartmentID);
        // or OrderByDescending

        foreach (var item in results)
            Console.WriteLine(
                $"Id : {item.Id, -5} First Name : {item.FirstName, -10} Last Name : {item.LastName, -10} Annual Salary : {item.AnnualSalary, 10}\tDepartment : {item.DepartmentName}"
            );
    }

    static void OrderByQuerySyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            orderby dept.Id
            select new
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                AnnualSalary = emp.AnnualSalary,
                DepartmentName = dept.LongName
            };

        foreach (var item in results)
            Console.WriteLine(
                $"Id : {item.Id, -5} First Name : {item.FirstName, -10} Last Name : {item.LastName, -10} Annual Salary : {item.AnnualSalary, 10}\tDepartment : {item.DepartmentName}"
            );
    }

    static void ThenByMethodSyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        var results = employeeList
            .Join(
                departmentList,
                (e) => e.DepartmentId,
                (d) => d.Id,
                (emp, dept) =>
                    new
                    {
                        Id = emp.Id,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        AnnualSalary = emp.AnnualSalary,
                        DepartmentID = dept.Id,
                        DepartmentName = dept.LongName
                    }
            )
            .OrderBy(i => i.DepartmentID)
            .ThenBy(i => i.AnnualSalary);

        // or OrderByDescending
        // or ThenByDescending
        // You can add Reverse to reverse all order

        foreach (var item in results)
            Console.WriteLine(
                $"Id : {item.Id, -5} First Name : {item.FirstName, -10} Last Name : {item.LastName, -10} Annual Salary : {item.AnnualSalary.ToString("C0", new CultureInfo("en-US")), 10}\tDepartment : {item.DepartmentName}"
            );
    }

    static void ThenByQuerySyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            orderby dept.Id descending, emp.AnnualSalary /* add 'descending' keyword to descend */
            select new
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                AnnualSalary = emp.AnnualSalary,
                DepartmentName = dept.LongName
            };

        foreach (var item in results)
            Console.WriteLine(
                $"Id : {item.Id, -5} First Name : {item.FirstName, -10} Last Name : {item.LastName, -10} Annual Salary : {item.AnnualSalary.ToString("C0", new CultureInfo("en-US")), 10}\tDepartment : {item.DepartmentName}"
            );
    }

    static void GroupByMethodSyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        var groupedByDepartment = employeeList
            .OrderBy(e => e.DepartmentId)
            .GroupBy(e => e.DepartmentId);

        foreach (var group in groupedByDepartment)
        {
            Console.WriteLine($"Department ID : {group.Key}");
            int count = 1;
            foreach (var item in group)
            {
                Console.WriteLine($"{count, 3}. {item.FirstName} {item.LastName}");
                count++;
            }
            Console.WriteLine();
        }
    }

    static void GroupByQuerySyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        var groupedByDepartment =
            from emp in employeeList
            orderby emp.DepartmentId
            group emp by emp.DepartmentId;

        foreach (var group in groupedByDepartment)
        {
            Console.WriteLine($"Department ID : {group.Key}");
            int count = 1;
            foreach (var item in group)
            {
                Console.WriteLine($"{count, 3}. {item.FirstName} {item.LastName}");
                count++;
            }
            Console.WriteLine();
        }
    }

    static void ToLookUpMethodSyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        var employeesByDepartment = employeeList.ToLookup(emp => emp.DepartmentId);

        var departmentId = 1;
        foreach (var emp in employeesByDepartment[departmentId])
        {
            Console.WriteLine($"Department ID: {departmentId}");
            Console.WriteLine($"  {emp.FirstName} {emp.LastName}");
        }
    }

    static void ToLookUpQuerySyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        var employeesByDepartment =
            from emp in employeeList
            group emp by emp.DepartmentId into deptGroup
            select deptGroup;

        var departmentId = 1;
        foreach (var emp in employeesByDepartment.Single(group => group.Key == departmentId))
        {
            Console.WriteLine($"Department ID: {departmentId}");
            Console.WriteLine($"  {emp.FirstName} {emp.LastName}");
        }
    }

    static void SelectManyMethodSyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        string[] sentences =
        {
            "Lorem ipsum dolor sit amet, qui minim labore adipisicing minim sint cillum sint consectetur cupidatat",
            "A brown fox jump over the fence in the backyard",
            "An elephant is playing with the group of lambs",
            "Mr.Smith is getting married next week at the Vineyard"
        };

        var allWordsAcrossAllSentences = sentences.SelectMany(words => words.Split(" "));

        foreach (var word in allWordsAcrossAllSentences)
        {
            Console.WriteLine(word);
        }
    }

    static void SelectManyQuerySyntax(List<Employee> employeeList, List<Department> departmentList)
    {
        string[] sentences =
        {
            "Lorem ipsum dolor sit amet, qui minim labore adipisicing minim sint cillum sint consectetur cupidatat",
            "A brown fox jump over the fence in the backyard",
            "An elephant is playing with the group of lambs",
            "Mr.Smith is getting married next week at the Vineyard"
        };

        var allWordsAcrossAllSentences =
            from words in sentences
            from word in words.Split(" ")
            select word;

        foreach (var word in allWordsAcrossAllSentences)
        {
            Console.WriteLine(word);
        }
    }

    static void Distinct()
    {
        string[] names = { "Madison", "John", "Klara", "John", "Alice", "Jamal", "Alice" };

        var distinctNames = names.Distinct();

        foreach (var name in distinctNames)
        {
            Console.WriteLine(name);
        }
    }

    static void DistinctBy(List<Employee> employeeList, List<Department> departmentList)
    {
        var employeesWithDepartment =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var distinctDepartment = employeesWithDepartment.DistinctBy(e => e.Department);

        foreach (var item in distinctDepartment)
        {
            Console.WriteLine(item);
        }
    }

    static void Except()
    {
        var collection1 = new List<string> { "Alice", "Bob", "Charlie", };

        var collection2 = new List<string> { "Alice", "Donna", "Kimbel", };

        var exceptResult = collection1.Except(collection2);
        foreach (var item in exceptResult)
        {
            Console.WriteLine(item);
        }
    }

    static void ExceptBy()
    {
        var candidates = new List<Person>
        {
            new Person() { SSN = "1234567890", Name = "John Doe" },
            new Person() { SSN = "1234567891", Name = "Jane Doe" },
            new Person() { SSN = "1234567892", Name = "Emily Johnson" },
            new Person() { SSN = "1234567893", Name = "William Brown" },
            new Person() { SSN = "1234567894", Name = "Sarah Davis" },
        };

        var employees = new List<Person>
        {
            new Person() { SSN = "1234567890", Name = "John Doe" },
            new Person() { SSN = "1234567891", Name = "Jane Doe" }
        };

        var potentialCandidate = candidates.ExceptBy(employees.Select(e => e.SSN), e => e.SSN);

        foreach (var item in potentialCandidate)
        {
            Console.WriteLine(item.ToString());
        }
    }

    static void Intersect()
    {
        var collection1 = new List<string> { "Alice", "Bob", "Charlie", };

        var collection2 = new List<string> { "Alice", "Donna", "Kimbel", };

        var exceptResult = collection1.Intersect(collection2);
        foreach (var item in exceptResult)
        {
            Console.WriteLine(item);
        }
    }

    static void IntersectBy()
    {
        var candidates = new List<Person>
        {
            new Person() { SSN = "1234567890", Name = "John Doe" },
            new Person() { SSN = "1234567891", Name = "Jane Doe" },
            new Person() { SSN = "1234567892", Name = "Emily Johnson" },
            new Person() { SSN = "1234567893", Name = "William Brown" },
            new Person() { SSN = "1234567894", Name = "Sarah Davis" },
        };

        var employees = new List<Person>
        {
            new Person() { SSN = "1234567890", Name = "John Doe" },
            new Person() { SSN = "1234567891", Name = "Jane Doe" }
        };

        var potentialCandidate = candidates.IntersectBy(employees.Select(e => e.SSN), e => e.SSN);

        foreach (var item in potentialCandidate)
        {
            Console.WriteLine(item.ToString());
        }
    }

    static void All()
    {
        List<Market> markets = new List<Market>
        {
            new Market { Name = "Emily's", Items = new string[] { "kiwi", "cheery", "banana" } },
            new Market { Name = "Kim's", Items = new string[] { "melon", "mango", "olive" } },
            new Market { Name = "Adam's", Items = new string[] { "kiwi", "apple", "orange" } },
        };

        var names =
            from market in markets
            where market.Items.All(item => item.Length == 5)
            select market.Name;

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    static void Any()
    {
        List<Market> markets = new List<Market>
        {
            new Market { Name = "Emily's", Items = new string[] { "kiwi", "cheery", "banana" } },
            new Market { Name = "Kim's", Items = new string[] { "melon", "mango", "olive" } },
            new Market { Name = "Adam's", Items = new string[] { "kiwi", "apple", "orange" } },
        };

        var names =
            from market in markets
            where market.Items.Any(item => item.Length == 5)
            select market.Name;

        foreach (var name in names)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
    }

    static void Contains()
    {
        List<Market> markets = new List<Market>
        {
            new Market { Name = "Emily's", Items = new string[] { "kiwi", "cheery", "banana" } },
            new Market { Name = "Kim's", Items = new string[] { "melon", "mango", "olive" } },
            new Market { Name = "Adam's", Items = new string[] { "kiwi", "apple", "orange" } },
        };

        var names = from market in markets where market.Items.Contains("kiwi") select market.Name;

        foreach (var name in names)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
    }

    static void First(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var employeeInTech = results.First((e) => e.Department == "Technology");

        Console.WriteLine($"Employee in Tech : {employeeInTech.FullName}");
    }

    static void FirstOrDefault(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var employeeInConstruction = results.FirstOrDefault((e) => e.Department == "Construction");
        var defaultEmployee =
            employeeInConstruction
            ?? new { FullName = "Bob The Builder", Department = "Construction" };

        Console.WriteLine($"Employee in Construction : {defaultEmployee.FullName}");
    }

    static void Last(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var employeeInTech = results.Last((e) => e.Department == "Technology");

        Console.WriteLine($"Employee in Tech : {employeeInTech.FullName}");
    }

    static void LastOrDefault(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var employeeInConstruction = results.LastOrDefault((e) => e.Department == "Social Media");
        var defaultEmployee =
            employeeInConstruction ?? new { FullName = "Emily", Department = "Social Media" };

        Console.WriteLine($"Employee in Construction : {defaultEmployee.FullName}");
    }

    static void Single(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var employeeInTech = results.Single((e) => e.Department == "Gay Division");

        Console.WriteLine($"Employee in Gay Division: {employeeInTech.FullName}");
    }

    static void SingleOrDefault(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var employeeInConstruction = results.SingleOrDefault((e) => e.Department == "Construction");
        var defaultEmployee =
            employeeInConstruction ?? new { FullName = "Jack Off", Department = "Analyst" };

        Console.WriteLine($"Employee in Analyst : {defaultEmployee.FullName}");
    }
}
