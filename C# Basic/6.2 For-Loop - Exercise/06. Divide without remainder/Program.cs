namespace _06.Divide_without_remainder
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    p1++;
                }

                if (num % 3 == 0)
                {
                    p2++;
                }

                if (num % 4 == 0)
                {
                    p3++;
                }
            }

            Console.WriteLine("{0:0.00}%", (p1 / n * 100.0));
            Console.WriteLine("{0:0.00}%", p2 / n * 100.0);
            Console.WriteLine("{0:0.00}%", p3 / n * 100.0);
        }
    }
}
