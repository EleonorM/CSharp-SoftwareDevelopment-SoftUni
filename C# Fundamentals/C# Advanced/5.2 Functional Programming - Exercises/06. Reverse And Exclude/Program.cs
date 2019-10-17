namespace _06._Reverse_And_Exclude
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int[], int[]> reverse = a => a = a.Reverse().ToArray();
            var numberToDivideBy = int.Parse(Console.ReadLine());
            Predicate<int> devisible = n => n % numberToDivideBy == 0;
            input = reverse(input);
            foreach (var num in input)
            {
                if (!devisible(num))
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
