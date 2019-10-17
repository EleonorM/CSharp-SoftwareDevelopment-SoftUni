namespace _06CircleAreaAndPerimeter
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var ridaus = double.Parse(Console.ReadLine());
            double area = Math.PI * ridaus * ridaus;
            double perimeter = 2 * Math.PI * ridaus;
            Console.WriteLine($"Area = {area}");
            Console.WriteLine($"Perimeter = {perimeter}");
        }
    }
}
