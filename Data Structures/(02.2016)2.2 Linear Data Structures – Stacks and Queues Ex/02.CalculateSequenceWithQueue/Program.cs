namespace _02.CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int number))
            {
                throw new InvalidOperationException();
            }

            var sequence = new List<int>();
            var queue = new Queue<int>();
            queue.Enqueue(number);
            sequence.Add(number);
            while (sequence.Count < 50)
            {
                var currentNum = queue.Dequeue();
                var num1 = currentNum + 1;
                queue.Enqueue(num1);
                sequence.Add(num1);

                var num2 = 2 * currentNum + 1;
                queue.Enqueue(num2);
                sequence.Add(num2);

                var num3 = currentNum + 2;
                queue.Enqueue(num3);
                sequence.Add(num3);
            }

            Console.WriteLine(string.Join(", ", sequence.Take(50)));
        }
    }
}
