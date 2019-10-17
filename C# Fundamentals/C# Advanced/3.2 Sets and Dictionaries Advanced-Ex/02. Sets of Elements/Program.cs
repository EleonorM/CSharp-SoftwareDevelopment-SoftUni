namespace _02._Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var setsSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < setsSize[0]; i++)
            {
                var number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < setsSize[1]; i++)
            {
                var name = int.Parse(Console.ReadLine());
                secondSet.Add(name);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine();
        }
    }
}
