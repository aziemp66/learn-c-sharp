namespace TCPData;

public class Person
{
    public required string SSN { get; set; }
    public required string Name { get; set; }

    public override string ToString() => $"{Name} <{SSN}>";

    public virtual void MyMethod(string parameter) { }
}
