namespace _12._Cups_and_Bottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            var wastedWater = 0;
            var currentCup = cups.Peek();
            while (true)
            {
                if (cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }
                else if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }

                var currentBottle = bottles.Pop();

                if (currentBottle >= currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                    cups.Dequeue();
                    if (cups.Count > 0)
                    {
                        currentCup = cups.Peek();
                    }
                }
                else
                {
                    currentCup -= currentBottle;
                }
            }
        }
    }
}
