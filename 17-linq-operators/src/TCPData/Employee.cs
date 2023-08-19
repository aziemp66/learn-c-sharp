namespace TCPData;

using System.Text.Json.Serialization;

public class Employee
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("annual_salary")]
    public decimal AnnualSalary { get; set; }

    [JsonPropertyName("is_manager")]
    public bool IsManager { get; set; }

    [JsonPropertyName("department_id")]
    public int DepartmentId { get; set; }

    public override string ToString()
    {
        return @$"First Name : {FirstName}
Last Name : {LastName}
Annual Salary : {AnnualSalary}
Is a Manager : {IsManager}
    ";
    }
}
