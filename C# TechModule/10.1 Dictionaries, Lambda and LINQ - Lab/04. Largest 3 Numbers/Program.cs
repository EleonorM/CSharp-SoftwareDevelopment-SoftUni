namespace _04.Largest_3_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => -x).Take(3).ToList();
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
