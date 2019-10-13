namespace _04.Vacation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var neededMoney = decimal.Parse(Console.ReadLine());
            var curentMoney = decimal.Parse(Console.ReadLine());
            var spendCounter = 0;
            var days = 0;
            bool isTrue = true;
            while (isTrue)
            {
                var action = Console.ReadLine();
                var money = decimal.Parse(Console.ReadLine());
                days++;
                if (action == "spend")
                {
                    spendCounter++;
                    curentMoney -= money;
                    if (curentMoney < 0)
                        curentMoney = 0;
                }
                else if (action == "save")
                {
                    curentMoney += money;
                    spendCounter = 0;
                }

                if (spendCounter == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine($"{days}");
                    isTrue = false;
                }

                if (curentMoney >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {days} days.");
                    isTrue = false;
                }
            }
        }
    }
}
