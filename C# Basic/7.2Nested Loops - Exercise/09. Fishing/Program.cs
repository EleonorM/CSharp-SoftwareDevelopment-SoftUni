namespace _09.Fishing
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var fisheshCount = int.Parse(Console.ReadLine());
            var count = 0;
            var sum = 0.0;
            for (int i = 1; i <= fisheshCount; i++)
            {
                var fishName = Console.ReadLine();
                if (fishName == "Stop")
                {
                    PrintResult(sum, count);
                    return;
                }
                var fishKg = double.Parse(Console.ReadLine());
                var sumFish = 0.0;
                foreach (char letter in fishName)
                {
                    sumFish += letter;
                }

                if (i % 3 == 0)
                {
                    sum += sumFish / fishKg;
                }
                else
                {
                    sum -= sumFish / fishKg;
                }

                count++;
            }

            Console.WriteLine("Lyubo fulfilled the quota!");
            PrintResult(sum, count);
        }

        public static void PrintResult(double sum, int count)
        {
            if (sum > 0)
            {
                Console.WriteLine($"Lyubo's profit from {count} fishes is {sum:f2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(sum):f2} leva today.");
            }
        }
    }
}
