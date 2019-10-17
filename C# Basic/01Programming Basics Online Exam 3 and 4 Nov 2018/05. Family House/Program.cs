namespace _05.Family_House
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var months = int.Parse(Console.ReadLine());
            var waterBill = 20.0;
            var internetBill = 15.0;
            var electricityAll = 0.0;
            var otherAll = 0.0;

            for (int i = 0; i < months; i++)
            {
                var electricityBill = double.Parse(Console.ReadLine());
                electricityAll += electricityBill;
                var otherBill = (electricityBill + waterBill + internetBill) + 0.2 * (electricityBill + waterBill + internetBill);
                otherAll += otherBill;
            }

            Console.WriteLine($"Electricity: {electricityAll:f2} lv");
            Console.WriteLine($"Water: {waterBill * months:f2} lv");
            Console.WriteLine($"Internet: {internetBill * months:f2} lv");
            Console.WriteLine($"Other: {otherAll:f2} lv");
            Console.WriteLine($"Average: {(otherAll + internetBill * months + waterBill * months + electricityAll) / months:f2} lv");
        }
    }
}
