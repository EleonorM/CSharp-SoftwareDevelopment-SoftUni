namespace _04._Add_VAT
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));
        }
    }
}
