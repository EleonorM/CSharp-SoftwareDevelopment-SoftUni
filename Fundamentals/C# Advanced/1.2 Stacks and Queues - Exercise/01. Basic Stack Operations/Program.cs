namespace _01._Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberOfElementsToPush = input[0];
            var numberOfElementsToPop = input[1];
            var chekForNumber = input[2];
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = new Stack<int>();
            for (int i = 0; i < numberOfElementsToPush; i++)
            {
                result.Push(numbers[i]);
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                result.Pop();
            }

            if (result.Contains(chekForNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                try
                {
                    Console.WriteLine(result.Min());
                }
                catch
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
