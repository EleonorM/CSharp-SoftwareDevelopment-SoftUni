namespace _03._Exact_Sum_of_Real_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numbers = int.Parse(Console.ReadLine());
            decimal sum = 0m;
            for (int i = 0; i < numbers; i++)
            {
                decimal first = decimal.Parse(Console.ReadLine());
                sum += first;
            }


            Console.WriteLine(sum);
        }
    }
}
