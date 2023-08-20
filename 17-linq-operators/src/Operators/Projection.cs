namespace Operators;

using TCPData;

public static class Projection
{
    public static void SelectManyMethodSyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
    {
        string[] sentences =
        {
            "Lorem ipsum dolor sit amet, qui minim labore adipisicing minim sint cillum sint consectetur cupidatat",
            "A brown fox jump over the fence in the backyard",
            "An elephant is playing with the group of lambs",
            "Mr.Smith is getting married next week at the Vineyard"
        };

        var allWordsAcrossAllSentences = sentences.SelectMany(words => words.Split(" "));

        foreach (var word in allWordsAcrossAllSentences)
        {
            Console.WriteLine(word);
        }
    }

    public static void SelectManyQuerySyntax(
        List<Employee> employeeList,
        List<Department> departmentList
    )
    {
        string[] sentences =
        {
            "Lorem ipsum dolor sit amet, qui minim labore adipisicing minim sint cillum sint consectetur cupidatat",
            "A brown fox jump over the fence in the backyard",
            "An elephant is playing with the group of lambs",
            "Mr.Smith is getting married next week at the Vineyard"
        };

        var allWordsAcrossAllSentences =
            from words in sentences
            from word in words.Split(" ")
            select word;

        foreach (var word in allWordsAcrossAllSentences)
        {
            Console.WriteLine(word);
        }
    }
}
