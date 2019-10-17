namespace _04.Number_sequence
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double maxNum = double.MinValue;
            double minNum = double.MaxValue;
            string word = "";
            while (true)
            {
                word = Console.ReadLine();
                if (word == "END")
                {
                    break;
                }

                double num = double.Parse(word);
                if (num > maxNum)
                {
                    maxNum = num;
                }

                if (num < minNum)
                {
                    minNum = num;
                }
            }

            Console.WriteLine($"Max number: {maxNum}");
            Console.WriteLine($"Min number: {minNum}");
        }
    }
}
