namespace _05TrapezoidArea
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine((b1 + b2) * h / 2);
        }
    }
}
