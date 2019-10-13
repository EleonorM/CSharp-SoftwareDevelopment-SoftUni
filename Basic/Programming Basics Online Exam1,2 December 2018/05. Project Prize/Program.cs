namespace _05.Project_Prize
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var partsProject = int.Parse(Console.ReadLine());
            var moneyForPoint = double.Parse(Console.ReadLine());
            var pointsTotal = 0.0;

            for (int i = 1; i <= partsProject; i++)
            {
                var points = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    pointsTotal += points * 2;
                }
                else
                {
                    pointsTotal += points;
                }
            }

            var moneyPrize = pointsTotal * moneyForPoint;
            Console.WriteLine($"The project prize was {moneyPrize:f2} lv.");
        }
    }
}
