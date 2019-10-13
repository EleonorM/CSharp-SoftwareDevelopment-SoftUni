namespace _02._Sum_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Func<string, int> parser = int.Parse;
            var numbers = input.Split(", ").Select(parser).ToList();
            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}
