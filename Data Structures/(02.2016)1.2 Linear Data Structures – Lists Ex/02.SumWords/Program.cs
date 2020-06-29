namespace _02.SumWords
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var words = input.Split(" ").ToList();
            words.Sort();

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
