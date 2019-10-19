namespace _05._MultiplicationSign
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number1 = int.Parse(Console.ReadLine());
            var number2 = int.Parse(Console.ReadLine());
            var number3 = int.Parse(Console.ReadLine());
            IsNegative(number1, number2, number3);
        }

        static void IsNegative(int n1, int n2, int n3)
        {
            bool isNegativeN1 = n1 < 0;
            bool isNegativeN2 = n2 < 0;
            bool isNegativeN3 = n3 < 0;
            if (isNegativeN1 && !isNegativeN2 && !isNegativeN3)
            {
                Console.WriteLine("negative");
            }
            else if (!isNegativeN1 && isNegativeN2 && !isNegativeN3)
            {
                Console.WriteLine("negative");
            }
            else if (!isNegativeN1 && !isNegativeN2 && isNegativeN3)
            {
                Console.WriteLine("negative");
            }
            else if (isNegativeN1 && isNegativeN2 && isNegativeN3)
            {
                Console.WriteLine("negative");
            }
            else if (n1 == 0 || n2 == 0 || n3 == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
