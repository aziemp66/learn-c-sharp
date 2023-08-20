namespace Operators;

using TCPData;
using System.Globalization;

public static class Aggregate
{
    enum TaxRate
    {
        Low = 40_000,
        Medium = 100_000,
        High = 200_000,
    }

    static decimal CountTax(decimal salary)
    {
        if (salary <= 0)
        {
            throw new InvalidOperationException();
        }

        if (salary <= ((decimal)TaxRate.Low))
        {
            return salary - (salary * 10 / 100);
        }
        else if (salary < ((decimal)TaxRate.Medium))
        {
            return salary - (salary * 30 / 100);
        }
        else if (salary < ((decimal)TaxRate.High))
        {
            return salary - (salary * 50 / 100);
        }
        else
        {
            return salary - (salary * 70 / 100);
        }
    }

    public static void CustomAggregate(List<Employee> employeeList)
    {
        var results = employeeList.Aggregate(
            0m,
            (sum, value) => sum + CountTax(value.AnnualSalary)
        );

        Console.WriteLine(
            $"Total Taxes Paid By All Employee : {results.ToString("C2", new CultureInfo("en-US"))}"
        );
    }
}
