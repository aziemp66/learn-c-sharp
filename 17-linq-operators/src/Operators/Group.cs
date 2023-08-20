namespace Operators;

using TCPData;

public static class Group
{
    public static void GroupByMethodSyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
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

    public static void GroupByQuerySyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
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

    public static void ToLookUpMethodSyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
    {
        var employeesByDepartment = employeeList.ToLookup(emp => emp.DepartmentId);

        var departmentId = 1;
        foreach (var emp in employeesByDepartment[departmentId])
        {
            Console.WriteLine($"Department ID: {departmentId}");
            Console.WriteLine($"  {emp.FirstName} {emp.LastName}");
        }
    }

    public static void ToLookUpQuerySyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
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
