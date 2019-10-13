namespace _05.New_House
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var flower = Console.ReadLine();
            var countFlowers = int.Parse(Console.ReadLine());
            var money = int.Parse(Console.ReadLine());

            double rosePrice = 5;
            double daliaPrice = 3.8;
            double tulipPrice = 2.8;
            double narcisPrice = 3;
            double gladiolusPrice = 2.5;
            var price = 0.00;

            if (flower == "Roses")
            {
                price = rosePrice * countFlowers;
                if (countFlowers > 80)
                    price -= rosePrice * countFlowers * 0.1;
            }
            else if (flower == "Dahlias")
            {
                price = daliaPrice * countFlowers;
                if (countFlowers > 90)
                    price -= daliaPrice * countFlowers * 0.15;
            }
            else if (flower == "Tulips")
            {
                price = tulipPrice * countFlowers;
                if (countFlowers > 80)
                    price -= tulipPrice * countFlowers * 0.15;
            }
            else if (flower == "Narcissus")
            {
                price = narcisPrice * countFlowers;
                if (countFlowers < 120)
                    price += narcisPrice * countFlowers * 0.15;
            }
            else if (flower == "Gladiolus")
            {
                price = gladiolusPrice * countFlowers;
                if (countFlowers < 80)
                    price += gladiolusPrice * countFlowers * 0.2;
            }

            if (money >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {flower} and {money - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(money - price):f2} leva more.");
            }
        }
    }
}
