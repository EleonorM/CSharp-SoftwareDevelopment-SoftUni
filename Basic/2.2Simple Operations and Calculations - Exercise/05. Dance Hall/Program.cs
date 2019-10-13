namespace _05.Dance_Hall
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var L = double.Parse(Console.ReadLine());
            var W = double.Parse(Console.ReadLine());
            var A = double.Parse(Console.ReadLine());

            var bench = L * 100 * W * 100 / 10;
            var wardrobe = A * A * 10000;
            var freeSpace = L * 100 * W * 100 - wardrobe - bench;
            Console.WriteLine(Math.Floor(freeSpace / (40 + 7000)));
        }
    }
}
