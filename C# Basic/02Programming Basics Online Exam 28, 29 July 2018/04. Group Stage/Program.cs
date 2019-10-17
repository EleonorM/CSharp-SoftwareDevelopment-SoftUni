namespace _04.Group_Stage
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var team = Console.ReadLine();
            var playedGames = int.Parse(Console.ReadLine());
            var points = 0;
            var counterEarned = 0;
            var counterLost = 0;
            for (int i = 0; i < playedGames; i++)
            {
                var goalsEarned = int.Parse(Console.ReadLine());
                var goalsLost = int.Parse(Console.ReadLine());
                counterEarned += goalsEarned;
                counterLost += goalsLost;
                if (goalsEarned > goalsLost)
                {
                    points += 3;
                }
                else if (goalsLost == goalsEarned)
                {
                    points++;
                }
            }

            if (counterEarned >= counterLost)
            {
                Console.WriteLine($"{team} has finished the group phase with {points} points.");
                Console.WriteLine($"Goal difference: {counterEarned - counterLost}.");
            }
            else
            {
                Console.WriteLine($"{team} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {counterEarned - counterLost}.");
            }
        }
    }
}
