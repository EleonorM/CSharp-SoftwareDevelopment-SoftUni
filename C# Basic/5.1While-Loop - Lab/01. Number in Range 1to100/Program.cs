namespace _01.Number_in_Range_1to100
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            while (n < 1 || n > 100)
            {
                Console.WriteLine("Invalid number");
                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("The number is: {0}", n);
        }
    }
}
