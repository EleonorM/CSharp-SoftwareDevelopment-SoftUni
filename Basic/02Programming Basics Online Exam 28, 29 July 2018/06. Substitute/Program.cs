namespace _06.Substitute
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var k = int.Parse(Console.ReadLine());
            var l = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var counter = 0;
            if (k % 2 != 0)
            {
                k++;
            }

            if (m % 2 != 0)
            {
                m++;
            }

            if (l % 2 == 0)
            {
                l++;
            }

            if (n % 2 == 0)
            {
                n++;
            }

            for (int x1 = k; x1 <= 8; x1 += 2)
            {
                for (int x2 = 9; x2 >= l; x2 -= 2)
                {
                    for (int x3 = m; x3 <= 8; x3 += 2)
                    {
                        for (int x4 = 9; x4 >= n; x4 -= 2)
                        {
                            if (x1 == x3 && x2 == x4)
                            {
                                Console.WriteLine("Cannot change the same player.");
                            }
                            else
                            {
                                Console.WriteLine($"{x1}{x2} - {x3}{x4}");
                                counter++;
                                if (counter == 6)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
