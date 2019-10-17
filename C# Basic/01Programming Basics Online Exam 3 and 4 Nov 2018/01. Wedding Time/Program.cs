namespace _01.Wedding_Time
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var wiskeyPrice = double.Parse(Console.ReadLine());
            var water = double.Parse(Console.ReadLine());
            var wine = double.Parse(Console.ReadLine());
            var champane = double.Parse(Console.ReadLine());
            var wiskey = double.Parse(Console.ReadLine());

            var champanePrice = wiskeyPrice * 1 / 2.0;
            var winePrice = champanePrice * 0.4;
            var waterPrice = champanePrice * 0.1;
            Console.WriteLine($"{wiskeyPrice * wiskey + water * waterPrice + winePrice * wine + champane * champanePrice:f2}");
        }
    }
}
