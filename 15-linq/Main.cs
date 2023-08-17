namespace PretendCompanyApplication;

using TCPData;
using TCPExtensions;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List<Employee> employeeList = Data.GetEmployees();
        //
        // var filteredEmployees = employeeList.Filter(emp => emp.AnnualSalary > 50000);
        //
        // foreach (var employee in filteredEmployees)
        // {
        //     Console.WriteLine(employee.ToString());
        // }
        //

        List<Department> departmentList = Data.GetDepartments();

        var filteredDepartments = departmentList.Filter((dpt) => dpt.ShortName == "HR");

        foreach (var department in filteredDepartments)
        {
            Console.WriteLine(department.ToString());
        }
    }
}
