namespace _01.ReverseNumbersWithAStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(input);
                return;
            }

            var numbers = input.Split(" ").Select(int.Parse).ToArray();
            var stack = new Stack<int>(numbers);
            var popedStack = new int[stack.Count];

            for (int i = 0; i < numbers.Length; i++)
            {
                popedStack[i] = stack.Pop();
            }

            Console.WriteLine(string.Join(" ", popedStack));
        }
    }
}
