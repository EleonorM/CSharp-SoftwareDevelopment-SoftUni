namespace _04.Coding
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            var number = num;
            var currentNumber = 0;

            for (int i = 0; i < num.ToString().Length; i++)
            {
                currentNumber = number % 10;
                if (currentNumber == 0)
                {
                    Console.WriteLine("ZERO");
                    number /= 10;
                    continue;
                }

                for (int j = 0; j < currentNumber; j++)
                {
                    Console.Write((char)((char)currentNumber + 33));
                }

                Console.WriteLine();
                number /= 10;
            }
        }
    }
}
