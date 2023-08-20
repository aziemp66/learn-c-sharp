namespace Operators;

using TCPData;
using System.Globalization;

public static class Sort
{
    public static void OrderByMethodSyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
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

    public static void OrderByQuerySyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
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

    public static void ThenByMethodSyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
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

    public static void ThenByQuerySyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
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
}
