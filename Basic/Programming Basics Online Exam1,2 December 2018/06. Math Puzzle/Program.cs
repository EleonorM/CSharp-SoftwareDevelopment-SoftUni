namespace _06.Math_Puzzle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var key = int.Parse(Console.ReadLine());
            var counter = 0;

            for (int x1 = 1; x1 <= 30; x1++)
            {
                for (int x2 = 1; x2 <= 30; x2++)
                {
                    for (int x3 = 1; x3 <= 30; x3++)
                    {
                        if (x1 + x2 + x3 == key)
                        {
                            if (x1 < x2 && x2 < x3)
                            {
                                Console.WriteLine($"{x1} + {x2} + {x3} = {x1 + x2 + x3}");
                                counter++;
                            }
                        }
                        else if (x1 * x2 * x3 == key)
                        {
                            if (x1 > x2 && x2 > x3)
                            {
                                Console.WriteLine($"{x1} * {x2} * {x3} = {x1 * x2 * x3}");
                                counter++;
                            }
                        }
                    }
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("No!");
                return;
            }
        }
    }
}
