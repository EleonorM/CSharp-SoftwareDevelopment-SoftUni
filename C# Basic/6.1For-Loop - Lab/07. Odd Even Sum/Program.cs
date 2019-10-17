namespace _07.Odd_Even_Sum
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var OddSum = 0;
            var EvenSum = 0;
            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                    EvenSum += num;
                else
                    OddSum += num;
            }

            if (OddSum == EvenSum)
            {
                Console.WriteLine("Yes, sum = " + EvenSum);
            }
            else
            {
                Console.WriteLine("No, diff = {0}", Math.Abs(EvenSum - OddSum));
            }
        }
    }
}
