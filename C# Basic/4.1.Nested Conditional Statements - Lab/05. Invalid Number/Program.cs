namespace _05.Invalid_Number
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var num = double.Parse(Console.ReadLine());
            var inRange = (num >= 100 && num <= 200 || num == 0);
            if (!inRange)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
