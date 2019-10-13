namespace _05.Computer_Firm
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var countComputers = int.Parse(Console.ReadLine());
            var sales = 0.00;
            var ratingNum = 0.00;

            for (int i = 0; i < countComputers; i++)
            {
                var numRating = int.Parse(Console.ReadLine());
                var rating = numRating % 10;
                ratingNum += rating;
                var salesPossible = numRating / 10;

                if (rating == 2)
                    sales += 0;
                else if (rating == 3)
                    sales += 0.5 * salesPossible;
                else if (rating == 4)
                    sales += 0.7 * salesPossible;
                else if (rating == 5)
                    sales += 0.85 * salesPossible;
                else if (rating == 6)
                    sales += 1 * salesPossible;
            }

            Console.WriteLine($"{sales:f2}");
            Console.WriteLine($"{ratingNum / countComputers:f2}");
        }
    }
}
