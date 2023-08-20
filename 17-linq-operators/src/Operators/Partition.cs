namespace Operators;

using TCPData;
using System.Globalization;

public static class Partition
{
    public static void Skip()
    {
        int[] marks = { 50, 42, 70, 83, 42, 90, 79 };
        var skippedMarks = marks.Skip(2);

        foreach (var item in skippedMarks)
        {
            Console.WriteLine(item);
        }
    }

    public static void SkipWhile(List<Employee> employeeList)
    {
        var SkippedWhileResults = employeeList
            .OrderBy((e) => e.AnnualSalary)
            .SkipWhile((e) => e.AnnualSalary < 100_000m);

        foreach (var employee in SkippedWhileResults)
        {
            Console.WriteLine(
                $"{employee.FirstName} {employee.LastName} : {employee.AnnualSalary.ToString("C0", new CultureInfo("en-US"))}"
            );
        }
    }
}
