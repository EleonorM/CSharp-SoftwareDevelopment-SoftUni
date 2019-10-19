namespace _01._Convert_Meters_to_Kilometers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine($"{input / 1000.0:f2}");
        }
    }
}
