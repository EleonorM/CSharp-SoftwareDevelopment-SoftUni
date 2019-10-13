namespace _02.Number_Pyramid
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var num = 1;
            for (int row = 1; row <= n; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    if (col >= 1)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(num);
                    num++;
                    if (num > n)
                    {
                        break;
                    }
                }

                Console.WriteLine();
                if (num > n)
                {
                    break;
                }
            }
        }
    }
}
