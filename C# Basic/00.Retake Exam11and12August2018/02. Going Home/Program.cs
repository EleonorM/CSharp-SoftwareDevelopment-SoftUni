namespace _02.Going_Home
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var distanceKm = int.Parse(Console.ReadLine());
            var gaz100Km = int.Parse(Console.ReadLine());
            var priceGaz1L = double.Parse(Console.ReadLine());
            var money = int.Parse(Console.ReadLine());

            double distancePrice = distanceKm / 100.0 * gaz100Km * priceGaz1L;
            if (money >= distancePrice)
            {
                Console.WriteLine($"You can go home. {money - distancePrice:f2} money left.");
            }
            else
            {
                Console.WriteLine($"Sorry, you cannot go home. Each will receive {money / 5.0:f2} money.");
            }
        }
    }
}
