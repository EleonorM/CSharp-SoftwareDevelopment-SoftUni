namespace _04._PrintingTriangle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            PrintHeader(number);
            PrintFooter(number);
        }

        static void PrintHeader(int number)
        {
            for (int row = 1; row <= number; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write($"{col} ");
                }

                Console.WriteLine();
            }
        }

        static void PrintFooter(int number)
        {
            for (int row = number - 1; row >= 1; row--)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(col + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
