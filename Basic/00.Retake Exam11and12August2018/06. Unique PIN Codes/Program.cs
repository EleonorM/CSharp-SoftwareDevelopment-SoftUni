namespace _06.Unique_PIN_Codes
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var upperFirst = int.Parse(Console.ReadLine());
            var upperSecond = int.Parse(Console.ReadLine());
            var upperThird = int.Parse(Console.ReadLine());

            for (int n1 = 1; n1 <= upperFirst; n1++)
            {
                if (n1 % 2 != 0)
                    continue;
                for (int n2 = 1; n2 <= upperSecond; n2++)
                {
                    if (n2 == 2 || n2 == 3 || n2 == 5 || n2 == 7)
                        n2 = n2;
                    else
                        continue;
                    for (int n3 = 1; n3 <= upperThird; n3++)
                    {
                        if (n3 % 2 != 0)
                            continue;
                        Console.WriteLine($"{n1} {n2} {n3}");
                    }
                }
            }
        }
    }
}
