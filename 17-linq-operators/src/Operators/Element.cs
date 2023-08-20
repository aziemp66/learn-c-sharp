namespace Operators;

using TCPData;

public static class Element
{
    public static void First(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var employeeInTech = results.First((e) => e.Department == "Technology");

        Console.WriteLine($"Employee in Tech : {employeeInTech.FullName}");
    }

    public static void FirstOrDefault(List<Employee> employeeList, List<Department> departmentList)
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

    public static void Last(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var employeeInTech = results.Last((e) => e.Department == "Technology");

        Console.WriteLine($"Employee in Tech : {employeeInTech.FullName}");
    }

    public static void LastOrDefault(List<Employee> employeeList, List<Department> departmentList)
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

    public static void Single(List<Employee> employeeList, List<Department> departmentList)
    {
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new { FullName = $"{emp.FirstName} {emp.LastName}", Department = dept.LongName };

        var employeeInTech = results.Single((e) => e.Department == "Gay Division");

        Console.WriteLine($"Employee in Gay Division: {employeeInTech.FullName}");
    }

    public static void SingleOrDefault(List<Employee> employeeList, List<Department> departmentList)
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
