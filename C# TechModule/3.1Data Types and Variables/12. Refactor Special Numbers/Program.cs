namespace _12._Refactor_Special_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = 0;
            bool ifFalse = false;
            for (int i = 1; i <= n; i++)
            {
                number = i;
                while (i != 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }
                ifFalse = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{number} -> {ifFalse}");
                sum = 0;
                i = number;

            }
        }
    }
}
