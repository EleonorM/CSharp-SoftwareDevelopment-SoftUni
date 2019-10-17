namespace _04._Find_Evens_or_Odds
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Predicate<int> even = n => n % 2 == 0;
            Predicate<int> odd = n => n % 2 != 0;
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var start = input[0];
            var end = input[1];
            var condition = Console.ReadLine().ToLower();
            if (condition == "odd")
            {
                for (int i = start; i <= end; i++)
                {
                    if (odd(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            else if (condition == "even")
            {
                for (int i = start; i <= end; i++)
                {
                    if (even(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
