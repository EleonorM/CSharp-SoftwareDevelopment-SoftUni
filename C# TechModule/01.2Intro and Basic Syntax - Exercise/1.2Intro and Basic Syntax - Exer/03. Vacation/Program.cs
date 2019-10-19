using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPeople = int.Parse(Console.ReadLine());
            string typePeople = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0.00;

            if (typePeople == "Students")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        price = 8.45; break;
                    case "Saturday":
                        price = 9.8; break;
                    case "Sunday":
                        price = 10.46; break;
                    default:
                        break;
                }
                
            }
            else if (typePeople == "Business")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        price = 10.9; break;
                    case "Saturday":
                        price = 15.6; break;
                    case "Sunday":
                        price = 16; break;
                    default:
                        break;
                }
                
            }
            else if (typePeople == "Regular")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        price = 15; break;
                    case "Saturday":
                        price = 20; break;
                    case "Sunday":
                        price = 22.5; break;
                    default:
                        break;
                }
            }
            var totalPrice = price * numberPeople;
            if (numberPeople >= 30 && typePeople == "Students")
            {
                totalPrice = totalPrice - 0.15 * totalPrice;
            }
            if (numberPeople >= 100 && typePeople == "Business")
            {
                totalPrice = totalPrice - 10 * price;
            }
            if (typePeople == "Regular" && numberPeople >= 10 && numberPeople <= 20)
            {
                totalPrice -= totalPrice * 0.05;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
