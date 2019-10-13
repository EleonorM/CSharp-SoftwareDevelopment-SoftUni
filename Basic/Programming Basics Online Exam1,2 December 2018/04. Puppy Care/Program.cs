namespace _04.Puppy_Care
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var foodKg = int.Parse(Console.ReadLine());
            var foodInStorage = foodKg * 1000;
            int allFood = 0;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Adopted")
                {
                    break;
                }

                var foodEaten = int.Parse(input);
                allFood += foodEaten;
            }

            if (allFood <= foodInStorage)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodInStorage - allFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {allFood - foodInStorage} grams more.");
            }
        }
    }
}
