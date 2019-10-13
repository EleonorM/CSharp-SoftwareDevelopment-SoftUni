namespace _03._Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var line = int.Parse(Console.ReadLine());
            var elements = new HashSet<string>();

            for (int i = 0; i < line; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in input)
                {
                    elements.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(x=>x)));
        }
    }
}
