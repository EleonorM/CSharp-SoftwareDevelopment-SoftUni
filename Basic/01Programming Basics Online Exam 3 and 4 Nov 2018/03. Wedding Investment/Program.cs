namespace _03.Wedding_Investment
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var contractrTime = Console.ReadLine();
            var contractType = Console.ReadLine();
            var addedDesert = Console.ReadLine();
            var months = int.Parse(Console.ReadLine());

            decimal monthTax = 0.0m;
            if (contractrTime == "one")
            {
                switch (contractType)
                {
                    case "Small":
                        monthTax = 9.98m;
                        break;
                    case "Middle":
                        monthTax = 18.99m;
                        break;
                    case "Large":
                        monthTax = 25.98m;
                        break;
                    case "ExtraLarge":
                        monthTax = 35.99m;
                        break;
                    default:
                        break;
                }
            }
            else if (contractrTime == "two")
            {
                switch (contractType)
                {
                    case "Small":
                        monthTax = 8.58m;
                        break;
                    case "Middle":
                        monthTax = 17.09m;
                        break;
                    case "Large":
                        monthTax = 23.59m;
                        break;
                    case "ExtraLarge":
                        monthTax = 31.79m;
                        break;
                    default:
                        break;
                }
            }

            if (addedDesert == "yes")
            {
                if (monthTax <= 10)
                {
                    monthTax += 5.50m;
                }
                else if (monthTax <= 30)
                {
                    monthTax += 4.35m;
                }
                else if (monthTax > 30)
                {
                    monthTax += 3.85m;
                }
            }

            if (contractrTime == "two")
            {
                monthTax = monthTax - 3.75m / 100m * monthTax;
            }

            Console.WriteLine($"{monthTax * months:f2} lv.");
        }
    }
}
