namespace _08._FactorialDivision
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double number1 = int.Parse(Console.ReadLine());
            double number2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"{Factorial(number1) / Factorial(number2):f2}");
        }

        static double Factorial(double number)
        {
            if (number == 1 || number == 0)
            {
                return 1;
            }

            var result = number * Factorial(number - 1);
            return result;
        }
    }
}
