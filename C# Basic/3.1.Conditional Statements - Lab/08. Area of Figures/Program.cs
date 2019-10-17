namespace _08.Area_of_Figures
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var figure = Console.ReadLine().ToLower();
            var a = double.Parse(Console.ReadLine());
            double b;
            if (figure == "square")
            {
                Console.WriteLine(Math.Round(a * a, 3));
            }
            else if (figure == "rectangle")
            {
                b = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(a * b, 3));
            }
            else if (figure == "circle")
            {
                Console.WriteLine(Math.Round(Math.PI * a * a, 3));
            }
            else if (figure == "triangle")
            {
                b = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(a * b / 2.0, 3));
            }
        }
    }
}
