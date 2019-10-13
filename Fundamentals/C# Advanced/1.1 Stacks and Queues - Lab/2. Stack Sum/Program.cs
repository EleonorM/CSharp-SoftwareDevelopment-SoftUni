namespace _2._Stack_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            Stack<int> numbers = new Stack<int>();

            foreach (var number in input)
            {
                numbers.Push(int.Parse(number));
            }

            var inputOperations = Console.ReadLine().Split();
            while (inputOperations[0].ToLower() != "end")
            {
                if (inputOperations[0].ToLower() == "add")
                {
                    numbers.Push(int.Parse(inputOperations[1]));
                    numbers.Push(int.Parse(inputOperations[2]));
                }
                else if (inputOperations[0].ToLower() == "remove" && int.Parse(inputOperations[1]) <= numbers.Count)
                {
                    for (int i = 0; i < int.Parse(inputOperations[1]); i++)
                    {
                        numbers.Pop();
                    }
                }

                inputOperations = Console.ReadLine().Split();
            }

            int sum = 0;
            while (numbers.Any())
            {
                sum += numbers.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
