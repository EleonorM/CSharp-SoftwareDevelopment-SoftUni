namespace _03._LongerLine
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double dist12 = CalcDistanceBetweenPoints(x1, y1, x2, y2);
            double dist34 = CalcDistanceBetweenPoints(x3, y3, x4, y4);
            if (dist12 >= dist34)
            {
                double dist1 = CalcDistance(x1, y1);
                double dist2 = CalcDistance(x2, y2);
                if (dist1 <= dist2)
                {
                    Console.Write($"({x1}, {y1})");
                    Console.WriteLine($"({x2}, {y2})");
                }
                else
                {
                    Console.Write($"({x2}, {y2})");
                    Console.WriteLine($"({x1}, {y1})");
                }
            }
            else
            {
                double dist3 = CalcDistance(x3, y3);
                double dist4 = CalcDistance(x4, y4);
                if (dist3 <= dist4)
                {
                    Console.Write($"({x3}, {y3})");
                    Console.WriteLine($"({x4}, {y4})");
                }
                else
                {
                    Console.Write($"({x4}, {y4})");
                    Console.WriteLine($"({x3}, {y3})");
                }
            }
        }

        public static double CalcDistance(double x, double y)
        {
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distance;
        }

        public static double CalcDistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
            double lineLength = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return lineLength;
        }
    }
}
