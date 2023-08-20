namespace LinqOperators;

using System.Linq;
using TCPData;
using Operators;

public class Program
{
    static void Main(string[] args)
    {
        var employeeList = Dummy.GetEmployees();
        var departmentList = Data.GetDepartments();

        // Sort.OrderByMethodSyntax(employeeList, departmentList);
        // Sort.OrderByQuerySyntax(employeeList, departmentList);

        // Sort.ThenByMethodSyntax(employeeList, departmentList);
        // Sort.ThenByQuerySyntax(employeeList, departmentList);

        // Group.GroupByMethodSyntax(employeeList, departmentList);
        // Group.GroupByQuerySyntax(employeeList, departmentList);

        // Group.ToLookUpMethodSyntax(employeeList, departmentList);
        // Group.ToLookUpQuerySyntax(employeeList, departmentList);

        // Projection.SelectManyMethodSyntax(employeeList, departmentList);
        // Projection.SelectManyQuerySyntax(employeeList, departmentList);

        // Set.Distinct();
        // Set.DistinctBy(employeeList, departmentList);
        //
        // Set.Except();
        // Set.ExceptBy();
        //
        // Set.Intersect();
        // Set.IntersectBy();
        //
        // Set.Union();
        // Set.UnionBy();

        // Quantifier.All();
        // Quantifier.Any();
        // Quantifier.Contains();

        // Element.First(employeeList, departmentList);
        // Element.FirstOrDefault(employeeList, departmentList);
        // Element.Last(employeeList, departmentList);
        // Element.LastOrDefault(employeeList, departmentList);
        // Element.Single(employeeList, departmentList);
        // Element.SingleOrDefault(employeeList, departmentList);

        // Partition.Skip(employeeList);
        // Partition.SkipWhile(employeeList);

        // Partition.Take(employeeList);
        // Partition.TakeWhile(employeeList);

        Partition.Chunk(employeeList);
    }
}
