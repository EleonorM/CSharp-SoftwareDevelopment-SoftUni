namespace _1._Merge_Sort
{
using System;
    using System.Linq;

    public class Program
    {
      public  static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sorter = new MergeSort<int>();
            sorter.Sort(numbers);
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
