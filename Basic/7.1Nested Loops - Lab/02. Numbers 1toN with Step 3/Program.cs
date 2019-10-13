namespace _02.Numbers_1toN_with_Step_3
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i = i + 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
