namespace _06.Three_brothers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firstTime = double.Parse(Console.ReadLine());
            var secondTime = double.Parse(Console.ReadLine());
            var thirdTime = double.Parse(Console.ReadLine());
            var timeLeft = double.Parse(Console.ReadLine());
            var sum = 0.00;

            sum = 1 / (1.0 / firstTime + 1.0 / secondTime + 1.0 / thirdTime);
            var time = sum * 0.15 + sum;
            Console.WriteLine($"Cleaning time: {time:f2}");
            if (timeLeft - time >= 0)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeLeft - time):f0} hours.");
            }
            else
            {
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(time - timeLeft):f0} hours.");
            }
        }
    }
}
