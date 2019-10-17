namespace _02._Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberOfElementsToEnqueue = input[0];
            var numberOfElementsToDequeue = input[1];
            var chekForNumber = input[2];
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = new Queue<int>();
            for (int i = 0; i < numberOfElementsToEnqueue; i++)
            {
                result.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numberOfElementsToDequeue; i++)
            {
                result.Dequeue();
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
