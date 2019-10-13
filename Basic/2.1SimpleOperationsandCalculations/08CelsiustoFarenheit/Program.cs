namespace _08CelsiustoFarenheit
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var celsius = double.Parse(Console.ReadLine());

            var farenheit = 1.8 * celsius + 32;
            Console.WriteLine($"{farenheit:f2}");
        }
    }
}
