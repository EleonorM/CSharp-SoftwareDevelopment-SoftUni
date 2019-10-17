namespace _02.Bonus_Score
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var points = int.Parse(Console.ReadLine());
            var bonus = 0.00;

            if (points <= 100)
            {
                bonus += 5;
            }
            else if (points > 1000)
            {
                bonus += 0.1 * points;
            }
            else if (points > 100)
            {
                bonus += 0.2 * points;
            }

            if (points % 2 == 0)
            {
                bonus += 1;
            }
            else if (points % 5 == 0)
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(bonus + points);
        }
    }
}
