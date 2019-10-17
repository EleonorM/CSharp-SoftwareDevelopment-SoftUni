namespace _01.Sum_Seconds
{
    using System;

    public class Program
    {
        static void Main()
        {
            var time1 = int.Parse(Console.ReadLine());
            var time2 = int.Parse(Console.ReadLine());
            var time3 = int.Parse(Console.ReadLine());
            var sum = 0;
            var minutes = 0;
            var seconds = 0;

            sum = time1 + time2 + time3;
            if (sum >= 60)
            {
                minutes = sum / 60;
                seconds = sum % 60;
                Console.WriteLine($"{minutes}:{seconds:00}");
            }
            else
            {
                Console.WriteLine($"0:{sum:00}");
            }
        }
    }
}
