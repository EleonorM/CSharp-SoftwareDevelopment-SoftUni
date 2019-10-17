namespace _04.Best_Player
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var mostGoals = 0;
            var bestPlayer = "";
            while (true)
            {
                var name = Console.ReadLine();
                if (name == "END")
                {
                    break;
                }

                var goals = int.Parse(Console.ReadLine());
                if (goals > mostGoals)
                {
                    mostGoals = goals;
                    bestPlayer = name;
                }

                if (goals >= 10)
                {
                    break;
                }
            }

            Console.WriteLine($"{bestPlayer} is the best player!");
            if (mostGoals >= 3)
            {
                Console.WriteLine($"He has scored {mostGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {mostGoals} goals.");
            }
        }
    }
}
