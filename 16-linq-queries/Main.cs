namespace PretendCompanyApplication;

using TCPData;
using TCPExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public static class EnumerableCollectionExtensionsMethods
{
    public static IEnumerable<Employee> GetHighSalariedEmployees(
        this IEnumerable<Employee> employees
    )
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"Accessing employee : {employee.FirstName} {employee.LastName}");
            if (employee.AnnualSalary >= 50_000m)
            {
                yield return employee;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employeeList = Data.GetEmployees();
        List<Department> departmentList = Data.GetDepartments();

        // Select and Where Operator - Method Syntax (Immediate Execution)
        // var results = employeeList
        //     .Select(
        //         e => new { FullName = $"{e.FirstName} {e.LastName}", AnnualSalary = e.AnnualSalary }
        //     )
        //     .Where(e => e.AnnualSalary > 50000m);
        //
        // foreach (var item in results)
        // {
        //     Console.WriteLine($"{item.FullName,-20} : {item.AnnualSalary,10}");
        // }

        // Select and Where Operator - Query Syntax (Deffered Execution)
        // var results =
        //     from emp in employeeList
        //     where emp.AnnualSalary > 50_000m
        //     select new
        //     {
        //         FullName = $"{emp.FirstName} {emp.LastName}",
        //         AnnualSalary = emp.AnnualSalary
        //     };
        //
        // // Employee will be added to results despite only added later because of Deffered Execution
        // employeeList.Add(
        //     new Employee
        //     {
        //         Id = 5,
        //         FirstName = "Nabil",
        //         LastName = "Juliano",
        //         AnnualSalary = 150_000m
        //     }
        // );
        //
        // foreach (var item in results)
        // {
        //     Console.WriteLine($"{item.FullName,-20} : {item.AnnualSalary.ToString("n0"),10}");
        // }

        // Deferred Execution
        // var results =
        //     from emp in employeeList.GetHighSalariedEmployees()
        //     select new
        //     {
        //         FullName = $"{emp.FirstName} {emp.LastName}",
        //         AnnualSalary = emp.AnnualSalary
        //     };

        // Immediate Execution
        // var results = (
        //     from emp in employeeList.GetHighSalariedEmployees()
        //     select new
        //     {
        //         FullName = $"{emp.FirstName} {emp.LastName}",
        //         AnnualSalary = emp.AnnualSalary
        //     }
        // ).ToList();
        //
        // employeeList.Add(
        //     new Employee
        //     {
        //         Id = 5,
        //         FirstName = "Nabil",
        //         LastName = "Juliano",
        //         AnnualSalary = 150_000m
        //     }
        // );
        //
        // foreach (var item in results)
        // {
        //     Console.WriteLine(
        //         $"{item.FullName,-20} : {item.AnnualSalary.ToString("C0", new CultureInfo("fr-FR")),10}"
        //     );
        // }

        // Join Operation Example - Method Syntax
        // var results = departmentList.Join(
        //     employeeList,
        //     department => department.Id,
        //     employee => employee.DepartmentId,
        //     (department, employee) =>
        //         new
        //         {
        //             FullName = $"{employee.FirstName} {employee.LastName}",
        //             AnnualSalary = employee.AnnualSalary,
        //             DepartmentName = department.LongName
        //         }
        // );
        // foreach (var item in results)
        // {
        //     Console.WriteLine(
        //         $"{item.FullName,-20} : {item.AnnualSalary.ToString("C0", new CultureInfo("en-US")),10}\t{item.DepartmentName}"
        //     );
        // }

        // Join Operation Example - Query Syntax
        var results =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new
            {
                FullName = $"{emp.FirstName} {emp.LastName}",
                AnnualSalary = emp.AnnualSalary,
                DepartmentName = dept.LongName
            };

        employeeList.Add(
            new Employee
            {
                Id = 5,
                FirstName = "Nabil",
                LastName = "Juliano",
                AnnualSalary = 299_000m,
                DepartmentId = 3
            }
        );

        int count = 1;
        foreach (var item in results)
        {
            Console.WriteLine(
                $"{$"{count}.",-3} {item.FullName,-20} : {item.AnnualSalary.ToString("C0", new CultureInfo("en-US")),10}\t{item.DepartmentName}"
            );
            count++;
        }
    }
}
