namespace _05.Game_Info
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var team = Console.ReadLine();
            var meating = int.Parse(Console.ReadLine());
            var allTime = 0.0;
            var gamePenaltie = 0;
            var additionalTime = 0;
            for (int i = 0; i < meating; i++)
            {
                var lenghtMeating = int.Parse(Console.ReadLine());
                allTime += lenghtMeating;
                if (lenghtMeating > 120)
                {
                    gamePenaltie++;
                }
                else if (lenghtMeating > 90)
                {
                    additionalTime++;
                }
            }

            Console.WriteLine($"{team} has played {allTime} minutes. Average minutes per game: {allTime / meating:f2}");
            Console.WriteLine($"Games with penalties: {gamePenaltie}");
            Console.WriteLine($"Games with additional time: {additionalTime}");
        }
    }
}
