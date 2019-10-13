namespace _09.World_Swimming_Record
{
    using System;

    public class Program
    {
        public static void Main()
        {
            decimal worldRecord = decimal.Parse(Console.ReadLine());
            decimal distance = decimal.Parse(Console.ReadLine());
            decimal timeFor1m = decimal.Parse(Console.ReadLine());

            decimal time = distance * timeFor1m;
            if (distance >= 15)
            {
                var num = Math.Floor(distance / 15.0m);
                time += 12.5m * num;
            }

            if (time < worldRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {time - worldRecord:f2} seconds slower.");
            }
        }
    }
}
