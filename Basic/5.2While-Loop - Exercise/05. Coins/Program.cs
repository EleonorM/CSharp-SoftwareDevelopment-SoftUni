namespace _05.Coins
{
    using System;

    public class Program
    {
        public static void Main()
        {
            decimal money = decimal.Parse(Console.ReadLine());
            int count = 0;
            while (money >= 2m)
            {
                money -= 2m;
                count++;
            }

            while (money >= 1m)
            {
                money -= 1m;
                count++;
            }
            while (money >= 0.5m)
            {
                money -= 0.5m;
                count++;
            }

            while (money >= 0.5m)
            {
                money -= 0.5m;
                count++;
            }

            while (money >= 0.2m)
            {
                money -= 0.2m;
                count++;
            }
            while (money >= 0.1m)
            {
                money -= 0.1m;
                count++;
            }

            while (money >= 0.05m)
            {
                money -= 0.05m;
                count++;
            }

            while (money >= 0.02m)
            {
                money -= 0.02m;
                count++;
            }

            while (money >= 0.01m)
            {
                money -= 0.01m;
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
