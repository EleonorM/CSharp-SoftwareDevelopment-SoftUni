namespace _02._Knights_of_Honor
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new string[] { " ", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = name => Console.WriteLine($"Sir {name}");
            foreach (var item in input)
            {
                print(item);
            }
        }
    }
}
