namespace _05.Combination
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int x1 = 0; x1 <= num; x1++)
            {
                for (int x2 = 0; x2 <= num; x2++)
                {
                    for (int x3 = 0; x3 <= num; x3++)
                    {
                        for (int x4 = 0; x4 <= num; x4++)
                        {
                            for (int x5 = 0; x5 <= num; x5++)
                            {
                                if (x1 + x2 + x3 + x4 + x5 == num)
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
