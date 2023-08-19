namespace LinqOperators;

using TCPData;

public class Program
{
    static void Main(string[] args)
    {
        var employeeList = Data.GetEmployees();
        var departmentList = Data.GetDepartments();

        OrderByOperator(employeeList, departmentList);
    }

    static void OrderByOperator(List<Employee> employeeList, List<Department> departmentList)
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
}
