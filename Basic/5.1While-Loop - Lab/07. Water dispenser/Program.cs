namespace _07.Water_dispenser
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int ml = int.Parse(Console.ReadLine());
            var sum = 0;
            int tapped = 0;
            while (true)
            {
                var button = Console.ReadLine();
                if (button == "Easy")
                {
                    sum += 50;
                }
                else if (button == "Medium")
                {
                    sum += 100;
                }
                else if (button == "Hard")
                {
                    sum += 200;
                }
                tapped++;
                if (sum > ml)
                {
                    Console.WriteLine($"{sum - ml}ml has been spilled.");
                    break;
                }
                else if (sum == ml)
                {
                    Console.WriteLine($"The dispenser has been tapped {tapped} times.");
                    break;
                }
            }
        }
    }
}
