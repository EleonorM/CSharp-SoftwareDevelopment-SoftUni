namespace _02._PrintNumbersInReverseOrder
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                array[i] = number;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
