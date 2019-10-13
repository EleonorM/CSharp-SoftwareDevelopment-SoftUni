namespace _05.Walking
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int sum = 0;
            bool ifTrue = true;
            while (ifTrue)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    ifTrue = false;
                    input = Console.ReadLine();
                }
                int steps = int.Parse(input);
                sum += steps;
                if (sum >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    break;
                }
                else if (ifTrue == false && sum < 10000)
                {
                    Console.WriteLine($"{10000 - sum} more steps to reach goal.");
                }
            }
        }
    }
}
