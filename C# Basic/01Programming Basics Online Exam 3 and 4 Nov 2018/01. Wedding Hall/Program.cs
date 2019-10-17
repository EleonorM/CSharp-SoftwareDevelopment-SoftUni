namespace _01.Wedding_Hall
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var lenght = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var barSide = double.Parse(Console.ReadLine());

            var bar = barSide * barSide;
            var dancing = 19 / 100.0 * lenght * width;
            Console.WriteLine(Math.Ceiling((lenght * width - bar - dancing) / 3.2));
        }
    }
}
