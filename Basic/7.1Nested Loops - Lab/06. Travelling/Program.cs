namespace _06.Travelling
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var country = input;
                var budget = double.Parse(Console.ReadLine());
                var money = 0.0;
                string savings = string.Empty;
                while (true)
                {
                    savings = Console.ReadLine();
                    if (savings == "End")
                    {
                        return;
                    }

                    money += double.Parse(savings);
                    if (money >= budget)
                    {
                        Console.WriteLine($"Going to {country}!");
                        break;
                    }
                }

                input = Console.ReadLine();
            }

        }
    }
}
