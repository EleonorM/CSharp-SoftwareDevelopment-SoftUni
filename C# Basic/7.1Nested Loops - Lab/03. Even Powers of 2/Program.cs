namespace _03.Even_Powers_of_2
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var num = 1;
            for (int i = 0; i <= n / 2; i++)
            {
                Console.WriteLine(num);
                num = num * 4;
            }
        }
    }
}
