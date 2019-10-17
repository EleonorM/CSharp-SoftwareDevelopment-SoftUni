namespace _09RadianstoDegrees
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var rad = double.Parse(Console.ReadLine());
            var c = rad * 180 / Math.PI;
            Console.WriteLine(Math.Round(c));
        }
    }
}
