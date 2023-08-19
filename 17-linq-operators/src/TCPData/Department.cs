namespace TCPData;

public class Department
{
    public int Id { get; set; }
    public string? ShortName { get; set; }
    public string? LongName { get; set; }

    public override string ToString()
    {
        return @$"Id : {Id}
Short Name : {ShortName}
Long Name : {LongName}";
    }
}
