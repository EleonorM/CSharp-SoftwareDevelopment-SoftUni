namespace _03._RecursiveFibonacci
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int fibbonachiNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibbonaci(fibbonachiNumber));
        }

        static int Fibbonaci(int n)
        {
            if (n == 2 || n == 1)
            {
                return 1;
            }

            int number = Fibbonaci(n - 1) + Fibbonaci(n - 2);
            return number;
        }
    }
}
