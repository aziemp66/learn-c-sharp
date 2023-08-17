namespace PretendCompanyApplication;

using TCPData;
using TCPExtensions;
using System.Collections.Generic;
using System.Linq;

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
        var results =
            from emp in employeeList
            where emp.AnnualSalary > 50_000m
            select new
            {
                FullName = $"{emp.FirstName} {emp.LastName}",
                AnnualSalary = emp.AnnualSalary
            };

        // Employee will be added to results despite only added later because of Deffered Execution
        employeeList.Add(
            new Employee
            {
                Id = 5,
                FirstName = "Nabil",
                LastName = "Juliano",
                AnnualSalary = 150_000m
            }
        );

        foreach (var item in results)
        {
            Console.WriteLine($"{item.FullName,-20} : {item.AnnualSalary,10}");
        }
    }
}
