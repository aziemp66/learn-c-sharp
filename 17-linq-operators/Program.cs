namespace LinqOperators;

using System.Globalization;
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

        ToLookUpMethodSyntax(employeeList, departmentList);
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
                $"Id : {item.Id,-5} First Name : {item.FirstName,-10} Last Name : {item.LastName,-10} Annual Salary : {item.AnnualSalary,10}\tDepartment : {item.DepartmentName}"
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
                $"Id : {item.Id,-5} First Name : {item.FirstName,-10} Last Name : {item.LastName,-10} Annual Salary : {item.AnnualSalary,10}\tDepartment : {item.DepartmentName}"
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
                $"Id : {item.Id,-5} First Name : {item.FirstName,-10} Last Name : {item.LastName,-10} Annual Salary : {item.AnnualSalary.ToString("C0", new CultureInfo("en-US")),10}\tDepartment : {item.DepartmentName}"
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
                $"Id : {item.Id,-5} First Name : {item.FirstName,-10} Last Name : {item.LastName,-10} Annual Salary : {item.AnnualSalary.ToString("C0", new CultureInfo("en-US")),10}\tDepartment : {item.DepartmentName}"
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
                Console.WriteLine($"{count,3}. {item.FirstName} {item.LastName}");
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
                Console.WriteLine($"{count,3}. {item.FirstName} {item.LastName}");
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
}
