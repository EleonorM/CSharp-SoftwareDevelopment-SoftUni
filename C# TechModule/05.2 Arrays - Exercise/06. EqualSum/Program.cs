namespace _06._EqualSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            bool isTrue = false;
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                if (i == 0)
                {
                    leftSum = 0;
                }
                else
                {
                    for (int k = 0; k < i; k++)
                    {
                        leftSum += numbers[k];
                    }
                }

                if (i == numbers.Length - 1)
                {
                    rightSum = 0;
                }
                else
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        rightSum += numbers[j];
                    }
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    isTrue = true;
                    break;
                }
            }

            if (isTrue == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
