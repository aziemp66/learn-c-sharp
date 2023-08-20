namespace Operators;

using TCPData;
using System.Globalization;

public static class Partition
{
    public static void Skip(List<Employee> employeeList)
    {
        var skippedResults = employeeList.Skip(20);

        foreach (var employee in skippedResults)
        {
            Console.WriteLine(
                $"{employee.FirstName} {employee.LastName} : {employee.AnnualSalary.ToString("C0", new CultureInfo("en-US"))}"
            );
        }
    }

    public static void SkipWhile(List<Employee> employeeList)
    {
        var skippedWhileResults = (
            from emp in employeeList
            orderby emp.AnnualSalary
            select emp
        ).SkipWhile(e => e.AnnualSalary < 100_000m);

        foreach (var employee in skippedWhileResults)
        {
            Console.WriteLine(
                $"{employee.FirstName} {employee.LastName} : {employee.AnnualSalary.ToString("C0", new CultureInfo("en-US"))}"
            );
        }
    }

    public static void Take(List<Employee> employeeList)
    {
        var takenResults = employeeList.Take(8);

        foreach (var employee in takenResults)
        {
            Console.WriteLine(
                $"{employee.FirstName} {employee.LastName} : {employee.AnnualSalary.ToString("C0", new CultureInfo("en-US"))}"
            );
        }
    }

    public static void TakeWhile(List<Employee> employeeList)
    {
        var takeWhileResults = (
            from emp in employeeList
            orderby emp.AnnualSalary
            select emp
        ).TakeWhile(e => e.AnnualSalary < 100_000m);

        foreach (var employee in takeWhileResults)
        {
            Console.WriteLine(
                $"{employee.FirstName} {employee.LastName} : {employee.AnnualSalary.ToString("C0", new CultureInfo("en-US"))}"
            );
        }
    }

    public static void Chunk(List<Employee> employeeList)
    {
        var chunkResults = employeeList.Chunk(3);

        int count = 1;
        foreach (var chunk in chunkResults)
        {
            Console.WriteLine($"Chunk {count} :");
            foreach (var employee in chunk)
            {
                Console.WriteLine(
                    $"{employee.FirstName} {employee.LastName} : {employee.AnnualSalary.ToString("C0", new CultureInfo("en-US"))}"
                );
            }
            count++;
            Console.WriteLine();
        }
    }
}
