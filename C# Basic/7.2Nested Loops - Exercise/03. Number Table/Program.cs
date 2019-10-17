namespace _03.Number_Table
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            for (int row = 0; row <= n - 1; row++)
            {
                for (int col = 0; col <= n - 1; col++)
                {
                    var num = row + col + 1;
                    if (num > n)
                    {
                        num = -num + 2 * n;
                    }

                    Console.Write(num + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
