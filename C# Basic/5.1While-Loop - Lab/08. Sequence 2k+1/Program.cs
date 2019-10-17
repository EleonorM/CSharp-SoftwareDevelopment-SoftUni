namespace _08.Sequence_2k_1
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var num = 1;
            while (num <= n)
            {
                Console.WriteLine(num);
                num = 2 * num + 1;
            }
        }
    }
}
