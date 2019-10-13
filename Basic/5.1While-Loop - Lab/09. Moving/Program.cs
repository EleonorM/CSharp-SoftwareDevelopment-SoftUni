namespace _09.Moving
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double volume = width * height * lenght;
            double sum = 0.00;
            while (true)
            {
                string word = Console.ReadLine();
                if (word == "Done")
                {
                    Console.WriteLine($"{volume - sum} Cubic meters left.");
                    break;
                }
                double box = double.Parse(word);
                sum += box;
                if (sum > volume)
                {
                    Console.WriteLine($"No more free space! You need {sum - volume} Cubic meters more.");
                    break;
                }
            }
        }
    }
}
