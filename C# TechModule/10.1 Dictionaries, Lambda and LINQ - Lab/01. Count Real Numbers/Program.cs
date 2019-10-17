namespace _01.Count_Real_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            SortedDictionary<double, int> resut = new SortedDictionary<double, int>();
            foreach (double number in numbers)
            {
                if (resut.ContainsKey(number))
                {
                    resut[number]++;
                }
                else
                {
                    resut.Add(number, 1);
                }
            }

            foreach (var num in resut)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
