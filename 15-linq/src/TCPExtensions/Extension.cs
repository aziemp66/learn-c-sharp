namespace TCPExtensions;

using System.Collections.Generic;

public static class Extension
{
    public static List<T> Filter<T>(this List<T> records, Predicate<T> func)
    {
        var filteredList = new List<T>();
        foreach (T record in records)
        {
            if (func(record))
            {
                filteredList.Add(record);
            }
        }
        return filteredList;
    }
}
