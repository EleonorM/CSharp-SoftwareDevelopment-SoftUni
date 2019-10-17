namespace _01._Sort_Even_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(", ").Select(int.Parse).Where(x => x % 2 == 0).OrderBy(x => x).ToList();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
