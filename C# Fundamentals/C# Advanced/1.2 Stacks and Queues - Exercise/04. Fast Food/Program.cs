namespace _04._Fast_Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var quantityOfFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());
            for (int i = 0; i < orders.Length; i++)
            {
                if (quantityOfFood - orders[i] >= 0)
                {
                    quantityOfFood = quantityOfFood - orders[i];
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
