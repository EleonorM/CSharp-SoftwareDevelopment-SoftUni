namespace _02._CarRace
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var times = Console.ReadLine().Split().Select(double.Parse).ToList();
            var timeLeft = 0.0;
            var timeRight = 0.0;
            for (int i = 0; i < times.Count / 2; i++)
            {
                if (times[i] == 0)
                {
                    timeLeft = timeLeft * 0.8;
                }
                timeLeft += times[i];
            }

            for (int i = times.Count - 1; i >= times.Count / 2 + 1; i--)
            {
                if (times[i] == 0)
                {
                    timeRight = timeRight * 0.8;
                }
                timeRight += times[i];
            }

            if (timeRight > timeLeft)
            {
                Console.WriteLine($"The winner is left with total time: {timeLeft}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {timeRight}");
            }
        }
    }
}
