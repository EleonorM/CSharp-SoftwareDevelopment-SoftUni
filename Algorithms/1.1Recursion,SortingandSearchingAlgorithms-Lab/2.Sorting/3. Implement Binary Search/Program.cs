namespace _3._Implement_Binary_Search
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var key = int.Parse(Console.ReadLine());
            var searcher = new BinarySearch();
            Console.WriteLine(searcher.IndexOf(numbers, key));
        }
    }
}
