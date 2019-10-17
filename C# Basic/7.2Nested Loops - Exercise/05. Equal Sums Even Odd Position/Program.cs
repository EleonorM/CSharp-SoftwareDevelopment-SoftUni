namespace _05.Equal_Sums_Even_Odd_Position
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            for (int i = startNumber; i <= endNumber; i++)
            {
                var d1 = i % 10;
                var d2 = i / 10 % 10;
                var d3 = i / 100 % 10;
                var d4 = i / 1000 % 10;
                var d5 = i / 10000 % 10;
                var d6 = i / 100000;
                if (d1 + d3 + d5 == d2 + d4 + d6)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
