namespace _09._List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var lastNumber = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x != 1)
                .Distinct()
                .ToArray();
            var numbers = new List<int>();
            if (lastNumber < 0)
            {
                numbers = Enumerable.Range(lastNumber, 1).ToList();
            }
            else
                numbers = Enumerable.Range(1, lastNumber).ToList();

            var predicates = new List<Predicate<int>>();

            foreach (var currentDivider in dividers)
            {
                predicates.Add(x => x % currentDivider == 0);
            }

            for (int i = 1; i <= numbers.Count; i++)
            {
                foreach (var currentPredicate in predicates)
                {
                    numbers = numbers.FindAll(currentPredicate);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
