namespace Operators;

using TCPData;

public static class Set
{
    public static void Distinct()
    {
        string[] names = { "Madison", "John", "Klara", "John", "Alice", "Jamal", "Alice" };

        var distinctNames = names.Distinct();

        foreach (var name in distinctNames)
        {
            Console.WriteLine(name);
        }
    }

    public static void DistinctBy(List<Employee> employeeList, List<Department> departmentList)
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

    public static void Except()
    {
        var collection1 = new List<string> { "Alice", "Bob", "Charlie", };

        var collection2 = new List<string> { "Alice", "Donna", "Kimbel", };

        var exceptResult = collection1.Except(collection2);
        foreach (var item in exceptResult)
        {
            Console.WriteLine(item);
        }
    }

    public static void ExceptBy()
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

    public static void Intersect()
    {
        var collection1 = new List<string> { "Alice", "Bob", "Charlie", };

        var collection2 = new List<string> { "Alice", "Donna", "Kimbel", };

        var exceptResult = collection1.Intersect(collection2);
        foreach (var item in exceptResult)
        {
            Console.WriteLine(item);
        }
    }

    public static void IntersectBy()
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

    public static void Union()
    {
        var collection1 = new List<string> { "Alice", "Bob", "Charlie", };

        var collection2 = new List<string> { "Alice", "Donna", "Kimbel", };

        var exceptResult = collection1.Union(collection2);
        foreach (var item in exceptResult)
        {
            Console.WriteLine(item);
        }
    }

    public static void UnionBy()
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
            new Person() { SSN = "7987871341", Name = "Azie Melza" },
            new Person() { SSN = "1234567890", Name = "John Doe" },
            new Person() { SSN = "1234567891", Name = "Jane Doe" }
        };

        var potentialCandidate = candidates.UnionBy(employees, e => e.SSN);

        foreach (var item in potentialCandidate)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
