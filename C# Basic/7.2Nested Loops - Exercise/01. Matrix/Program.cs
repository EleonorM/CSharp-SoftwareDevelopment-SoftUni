namespace _01.Matrix
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var startNumber1 = int.Parse(Console.ReadLine());
            var endNumber1 = int.Parse(Console.ReadLine());
            var startNumber2 = int.Parse(Console.ReadLine());
            var endNumber2 = int.Parse(Console.ReadLine());
            for (int x1 = startNumber1; x1 <= endNumber1; x1++)
            {
                for (int x2 = startNumber1; x2 <= endNumber1; x2++)
                {
                    for (int x3 = startNumber2; x3 <= endNumber2; x3++)
                    {
                        for (int x4 = startNumber2; x4 <= endNumber2; x4++)
                        {
                            if (x1 + x4 == x2 + x3 && x1 != x2 && x3 != x4)
                            {
                                Console.WriteLine($"{x1}{x2}");
                                Console.WriteLine($"{x3}{x4}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
