namespace _02.Spaceship
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var shipWidth = double.Parse(Console.ReadLine());
            var shipLenght = double.Parse(Console.ReadLine());
            var shipHeight = double.Parse(Console.ReadLine());
            var averageHeightAustronavts = double.Parse(Console.ReadLine());
            var shipVolume = shipHeight * shipLenght * shipWidth;
            var roomVolume = 2 * 2 * (averageHeightAustronavts + 0.4);
            var austronavts = Math.Floor(shipVolume / roomVolume);
            if (austronavts < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (austronavts <= 10)
            {
                Console.WriteLine($"The spacecraft holds {austronavts} astronauts.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
