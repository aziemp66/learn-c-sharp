namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int count = 0;
            Console.WriteLine("Start");
            Console.WriteLine(1);
            Console.WriteLine(2);
            Console.WriteLine(3);
        myLabel:
            Console.WriteLine(4);
            Console.WriteLine(5);
            count++;
            if (count <= 3)
            {
                goto myLabel;
            }
        }
    }
}
