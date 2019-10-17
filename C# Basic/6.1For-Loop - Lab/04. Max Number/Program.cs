namespace _04.Max_Number
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var max = int.Parse(Console.ReadLine());
            for (int i = 0; i < n - 1; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num > max)
                    max = num;
            }

            Console.WriteLine(max);
        }
    }
}
