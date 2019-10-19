namespace _02._FromLeftToTheRight
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                long sum = 0;
                var numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
                if (numbers[0] > numbers[1])
                {
                    long n = Math.Abs(numbers[0]);
                    while (n > 0)
                    {
                        sum += n % 10;
                        n /= 10;
                    }
                    Console.WriteLine(sum);
                }
                else
                {
                    long n = Math.Abs(numbers[1]);
                    while (n > 0)
                    {
                        sum += n % 10;
                        n /= 10;
                    }
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
