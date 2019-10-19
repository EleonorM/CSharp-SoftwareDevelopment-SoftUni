namespace _04._TribonacciSequence
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            Tribbonaci(number);
        }

        static void Tribbonaci(int n)
        {
            var numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == 1)
                {
                    numbers[i] = 1;
                }
                else if (i == 2)
                {
                    numbers[i] = 2;
                }
                else
                {
                    numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i - 3];
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
