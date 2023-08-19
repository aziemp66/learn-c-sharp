namespace TCPData;

using System.Collections.Generic;

public static class Data
{
    public static List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();

        Employee employee = new Employee
        {
            Id = 1,
            FirstName = "Bob",
            LastName = "Jones",
            AnnualSalary = 60000.3m,
            IsManager = true,
            DepartmentId = 2
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 2,
            FirstName = "Sarah",
            LastName = "Jameson",
            AnnualSalary = 80000.1m,
            IsManager = true,
            DepartmentId = 3
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 3,
            FirstName = "Douglas",
            LastName = "Roberts",
            AnnualSalary = 40000.2m,
            IsManager = false,
            DepartmentId = 1
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 4,
            FirstName = "Jane",
            LastName = "Stevens",
            AnnualSalary = 200_000.2m,
            IsManager = true,
            DepartmentId = 3
        };
        employees.Add(employee);

        employee = new Employee
        {
            Id = 5,
            FirstName = "Jane",
            LastName = "Stevens",
            AnnualSalary = 40_000.2m,
            IsManager = false,
            DepartmentId = 1
        };
        employees.Add(employee);

        employee = new Employee
        {
            Id = 6,
            FirstName = "John",
            LastName = "Smith",
            AnnualSalary = 55000.4m,
            IsManager = false,
            DepartmentId = 1
        };
        employees.Add(employee);

        employee = new Employee
        {
            Id = 7,
            FirstName = "Emily",
            LastName = "Johnson",
            AnnualSalary = 75000.5m,
            IsManager = true,
            DepartmentId = 2
        };
        employees.Add(employee);

        employee = new Employee
        {
            Id = 8,
            FirstName = "Michael",
            LastName = "Davis",
            AnnualSalary = 90000.6m,
            IsManager = false,
            DepartmentId = 2
        };
        employees.Add(employee);

        employee = new Employee
        {
            Id = 9,
            FirstName = "Amanda",
            LastName = "Williams",
            AnnualSalary = 65000.7m,
            IsManager = false,
            DepartmentId = 2
        };
        employees.Add(employee);

        employee = new Employee
        {
            Id = 10,
            FirstName = "Kevin",
            LastName = "Brown",
            AnnualSalary = 55000.8m,
            IsManager = true,
            DepartmentId = 3
        };
        employees.Add(employee);

        return employees;
    }

    public static List<Department> GetDepartments()
    {
        List<Department> departments = new List<Department>();

        Department department = new Department
        {
            Id = 1,
            ShortName = "HR",
            LongName = "Human Resources"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 2,
            ShortName = "FN",
            LongName = "Finance"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 3,
            ShortName = "TE",
            LongName = "Technology"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 4,
            ShortName = "MD",
            LongName = "Media"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 5,
            ShortName = "GAY",
            LongName = "Gay Division"
        };
        departments.Add(department);

        return departments;
    }
}
