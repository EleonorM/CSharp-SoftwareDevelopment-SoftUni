namespace _02.Mountain_Run
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var record = double.Parse(Console.ReadLine());
            var distance = double.Parse(Console.ReadLine());
            var timePerM = double.Parse(Console.ReadLine());

            double timeGoingUp = distance * timePerM;
            double TotalTime = Math.Floor(distance / 50) * 30 + timeGoingUp;

            if (TotalTime < record)
            {
                Console.WriteLine($"Yes! The new record is {TotalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {TotalTime - record:f2} seconds slower.");
            }
        }
    }
}
