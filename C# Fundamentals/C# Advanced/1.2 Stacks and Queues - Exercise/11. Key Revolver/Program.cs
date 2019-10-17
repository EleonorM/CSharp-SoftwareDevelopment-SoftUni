namespace _11._Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());
            var bulletsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var locksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var moneyToWin = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(bulletsInput);
            var locks = new Queue<int>(locksInput);
            var moneyEarned = moneyToWin;
            var barrelTotal = barrelSize;

            while (true)
            {
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                    break;
                }
                else if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }

                var currentBullet = bullets.Pop();
                var currentLock = locks.Peek();
                if (currentLock >= currentBullet)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                moneyEarned -= bulletPrice;
                barrelTotal--;
                if (barrelTotal == 0 && bullets.Count > 0)
                {
                    barrelTotal = barrelSize;
                    Console.WriteLine("Reloading!");
                }
            }
        }
    }
}
