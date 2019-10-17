namespace _10Birthday
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            var volume = lenght * width * height;
            Console.WriteLine("{0:0.000}", volume * 0.001 * (1 - percent * 0.01));
        }
    }
}
