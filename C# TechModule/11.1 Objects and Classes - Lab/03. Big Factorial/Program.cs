namespace _03.Big_Factorial
{
    using System;
    using System.Numerics;

    public class Program
    {
        private static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            BigInteger result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}
