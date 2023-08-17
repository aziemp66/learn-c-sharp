namespace TCPData;

public class Employee
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public bool IsManager { get; set; }
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
