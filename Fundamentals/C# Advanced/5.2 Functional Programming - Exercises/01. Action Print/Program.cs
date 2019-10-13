namespace _01._Action_Print
{
    using System;
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = message => Console.WriteLine(message);
            foreach (var item in input)
            {
                print(item);
            }
        }
    }
}
