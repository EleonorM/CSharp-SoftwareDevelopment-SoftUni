namespace _03._RoundingNumbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{array[i]} => {Math.Round(array[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
