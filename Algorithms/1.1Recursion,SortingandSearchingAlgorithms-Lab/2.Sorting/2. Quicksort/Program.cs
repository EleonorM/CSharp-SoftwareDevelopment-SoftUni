namespace _2._Quicksort
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sorter = new QuickSort<int>();
            sorter.Sort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
