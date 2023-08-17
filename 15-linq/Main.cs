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

        // var filteredEmployees = employeeList.Filter(emp => emp.AnnualSalary > 50000);
        //
        // foreach (var employee in filteredEmployees)
        // {
        //     Console.WriteLine(employee.ToString());
        // }
        //
        // var filteredDepartments = departmentList.Filter((dpt) => dpt.ShortName == "HR");
        //
        // foreach (var department in filteredDepartments)
        // {
        //     Console.WriteLine(department.ToString());
        // }

        // var filteredEmployees = employeeList.Where((e) => e.AnnualSalary > 50000m);
        //
        // foreach (var employee in filteredEmployees)
        // {
        //     Console.WriteLine(employee.ToString());
        // }


        var resultList =
            from emp in employeeList
            join dept in departmentList on emp.DepartmentId equals dept.Id
            select new
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                AnnualSalary = emp.AnnualSalary,
                Manager = emp.IsManager,
                Department = dept.LongName
            };

        foreach (var employee in resultList)
        {
            Console.WriteLine($"First Name: {employee.FirstName}");
            Console.WriteLine($"Last Name: {employee.LastName}");
            Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
            Console.WriteLine($"Manager: {employee.Manager}");
            Console.WriteLine($"Department: {employee.Department}");
            Console.WriteLine();
        }

        var averageSalary = resultList.Average(e => e.AnnualSalary);
        var highestSalary = resultList.Max(e => e.AnnualSalary);
        var lowestSalary = resultList.Min(e => e.AnnualSalary);

        Console.WriteLine($"Average Salary : {averageSalary}");
        Console.WriteLine($"Highest Salary : {highestSalary}");
        Console.WriteLine($"Lowest Salary : {lowestSalary}");
    }
}
