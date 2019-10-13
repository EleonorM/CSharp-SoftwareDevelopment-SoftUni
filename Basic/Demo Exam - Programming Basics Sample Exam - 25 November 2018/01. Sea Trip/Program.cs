namespace _01.Sea_Trip
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var moneyForFood = double.Parse(Console.ReadLine());
            var moneyForSouvenier = double.Parse(Console.ReadLine());
            var moneyForHotel = double.Parse(Console.ReadLine());
            var benzinLiters = 420 / 100.0 * 7;
            var moneyForGas = benzinLiters * 1.85;
            var firstDayHotel = moneyForHotel * 0.9;
            var secondDayHotel = moneyForHotel * 0.85;
            var thirdDayHotel = moneyForHotel * 0.8;

            var sum = 3 * (moneyForSouvenier + moneyForFood) + moneyForGas + firstDayHotel + secondDayHotel + thirdDayHotel;
            Console.WriteLine($"Money needed: {sum:f2}");
        }
    }
}
