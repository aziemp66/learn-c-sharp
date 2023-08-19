namespace TCPData;

using System.Text.Json;

public class Dummy
{
    public static List<Employee> GetEmployees()
    {
        string mockPath = Path.Combine(Directory.GetCurrentDirectory(), "mock", "employees.json");
        string mockData = File.ReadAllText(mockPath);

        List<Employee> employeeList =
            JsonSerializer.Deserialize<List<Employee>>(mockData)
            ?? throw new JsonException("Mock Data Not Found");

        return employeeList;
    }
}
