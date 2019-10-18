namespace _08._Town_Info
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var townName = Console.ReadLine();
            long population = long.Parse(Console.ReadLine());
            double area = double.Parse(Console.ReadLine());
            Console.WriteLine($"Town {townName} has population of {population} and area {area} square km.");
        }
    }
}
