namespace _01.School_Supplies
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var countPencil = int.Parse(Console.ReadLine());
            var countMarker = int.Parse(Console.ReadLine());
            var literCleaner = double.Parse(Console.ReadLine());
            var discount = int.Parse(Console.ReadLine());

            double moneyNeeded = countPencil * 5.8 + countMarker * 7.2 + literCleaner * 1.2;
            double moneyDiscount = moneyNeeded * discount / 100.0;
            Console.WriteLine($"{moneyNeeded - moneyDiscount:f3}");
        }
    }
}
