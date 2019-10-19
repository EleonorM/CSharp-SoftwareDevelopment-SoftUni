namespace _01._SmallestOfThreeNumbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            PrintGreatest(number1, number2, number3);
        }

        static void PrintGreatest(int n1, int n2, int n3)
        {
            int smallestNumber = 0;
            if (n1 < n2)
            {
                smallestNumber = n1;
                if (n3 < n1)
                {
                    smallestNumber = n3;
                }
            }
            else
            {
                smallestNumber = n2;
                if (n3 < n2)
                {
                    smallestNumber = n3;
                }
            }

            Console.WriteLine(smallestNumber);
        }
    }
}
