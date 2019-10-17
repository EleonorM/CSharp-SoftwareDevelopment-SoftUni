namespace _06.Account_Balance
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0.00;

            for (int i = 0; i < n; i++)
            {
                double price = double.Parse(Console.ReadLine());
                if (price >= 0)
                {
                    Console.WriteLine($"Increase: {price:f2}");
                    sum += price;
                }
                else
                {
                    Console.WriteLine($"Invalid operation!");
                    break;
                }
            }

            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
