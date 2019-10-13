namespace _08.Divisible_by_3
{
    using System;

    public class Program
    {
        public static void Main()
        {
            for (int i = 3; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
