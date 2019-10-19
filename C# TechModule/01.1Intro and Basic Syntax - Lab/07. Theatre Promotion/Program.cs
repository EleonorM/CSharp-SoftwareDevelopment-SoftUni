namespace _07.Theatre_Promotion
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var typeOfDay = Console.ReadLine().ToLower();
            var age = int.Parse(Console.ReadLine());
            var price = 0.00;

            if (typeOfDay == "weekday")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    price = 12;
                }
                else if (18 < age && age <= 64)
                    price = 18;
            }
            else if (typeOfDay == "weekend")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    price = 15;
                }
                else if (18 < age && age <= 64)
                    price = 20;
            }
            else if (typeOfDay == "holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 5;
                }
                else if (18 < age && age <= 64)
                    price = 12;
                else if (age > 64 && age <= 122)
                    price = 10;
            }

            if (price != 0)
                Console.WriteLine($"{price}$");
            else
                Console.WriteLine("Error!");
        }
    }
}
