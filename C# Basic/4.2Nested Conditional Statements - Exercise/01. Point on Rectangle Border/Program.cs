namespace _01.Point_on_Rectangle_Border
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
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());

            if ((x1 == x || x == x2) && (y1 <= y && y <= y2))
            {
                Console.WriteLine("Border");
            }
            else if ((x1 <= x && x <= x2) && (y1 == y || y == y2))
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
