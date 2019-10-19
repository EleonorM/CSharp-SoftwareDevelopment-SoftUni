namespace _06._CalculateRectangleArea
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateRectangleArea(width, height));
        }

        static double CalculateRectangleArea(int height, int width)
        {
            return width * height;
        }
    }
}
