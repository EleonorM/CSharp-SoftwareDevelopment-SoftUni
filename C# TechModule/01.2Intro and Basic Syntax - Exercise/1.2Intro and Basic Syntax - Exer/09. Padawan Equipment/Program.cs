using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double allMoney = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceLightsaber = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            var neededMoney = 0.00;

            int robeCount = students;
            int lightsaberCount = Convert.ToInt32(Math.Ceiling(1.1*students));
            int beltCount = students - students/6;
            
            neededMoney = robeCount * priceRobe + lightsaberCount * priceLightsaber + beltCount * priceBelt;
            if (allMoney>=neededMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {neededMoney-allMoney:f2}lv more.");
            }
        }
    }
}
