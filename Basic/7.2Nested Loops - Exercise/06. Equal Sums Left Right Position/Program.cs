namespace _06.Equal_Sums_Left_Right_Position
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            for (int i = startNumber; i <= endNumber; i++)
            {
                var d1 = i % 10;
                var d2 = i / 10 % 10;
                var d3 = i / 100 % 10;
                var d4 = i / 1000 % 10;
                var d5 = i / 10000;
                var minSum = Math.Min((d1 + d2), (d4 + d5));
                var maxSum = Math.Max((d1 + d2), (d4 + d5));
                if (d1 + d2 == d4 + d5)
                {
                    Console.Write($"{i} ");
                }
                else if (minSum + d3 == maxSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
