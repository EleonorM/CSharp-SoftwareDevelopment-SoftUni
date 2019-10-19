namespace _07._AppendArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arrays = Console.ReadLine().Split("|").ToList();
            var result = new List<int>();
            for (int i = arrays.Count - 1; i >= 0; i--)
            {
                var list = arrays[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                foreach (var item in list)
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
