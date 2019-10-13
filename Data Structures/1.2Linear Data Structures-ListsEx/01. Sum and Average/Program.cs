namespace _01._Sum_and_Average
{
    using System;
    using System.Linq;

    partial class Program
    {
        public static void Main()
        {
            var item = Console.ReadLine();
            if (item == "")
            {
                item = "0";
            }

            int[] array = item.Split().Select(int.Parse).ToArray();
            var sum = 0.00;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            Console.WriteLine($"Sum={sum}; Average={sum / array.Length:f2}");
        }
    }
}
