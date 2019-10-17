namespace _01._2D_Rectangle_Area
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var lenght = Math.Abs(x1 - x2);
            var width = Math.Abs(y1 - y2);
            Console.WriteLine(lenght * width);
            Console.WriteLine(2 * lenght + 2 * width);
        }
    }
}
