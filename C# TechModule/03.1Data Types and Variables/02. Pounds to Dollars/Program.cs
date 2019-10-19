namespace _02._Pounds_to_Dollars
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double input = double.Parse(Console.ReadLine());
            Console.WriteLine($"{input * 1.31:f3}");
        }
    }
}
