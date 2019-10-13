namespace _07TriangleArea
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var a = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            Console.WriteLine("Triangle area = {0:0.00}", a * h / 2);
        }
    }
}
