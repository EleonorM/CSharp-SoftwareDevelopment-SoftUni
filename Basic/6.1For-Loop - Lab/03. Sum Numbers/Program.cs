namespace _03.Sum_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }

            Console.WriteLine(sum);
        }
    }
}
