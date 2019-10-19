namespace _05._AddAndSubtract
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            int result = Substract(Sum(number1, number2), number3);
            Console.WriteLine(result);
        }

        static int Sum(int number1, int number2)
        {
            return number1 + number2;
        }

        static int Substract(int sum, int number3)
        {
            return sum - number3;
        }
    }
}
