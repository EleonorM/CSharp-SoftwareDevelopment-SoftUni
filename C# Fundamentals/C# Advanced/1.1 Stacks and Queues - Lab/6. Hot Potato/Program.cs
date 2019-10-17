namespace _6._Hot_Potato
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var allChildren = Console.ReadLine().Split();
            Queue<string> child = new Queue<string>(allChildren);
            int counter = 1;
            int n = int.Parse(Console.ReadLine());
            while (child.Count > 1)
            {
                var currentChild = child.Dequeue();
                if (counter % n != 0)
                {
                    child.Enqueue(currentChild);
                }
                else
                {
                    Console.WriteLine($"Removed {currentChild}");
                }

                counter++;
            }

            Console.WriteLine($"Last is {child.Dequeue()}");
        }
    }
}
