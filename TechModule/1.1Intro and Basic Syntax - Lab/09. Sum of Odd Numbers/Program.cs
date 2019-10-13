namespace _09.Sum_of_Odd_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var oddNumbers = int.Parse(Console.ReadLine());
            var sum = 0.00;
            var counter = 0;

            for (int i = 1; counter < oddNumbers; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                    sum += i;
                    counter++;
                }
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
