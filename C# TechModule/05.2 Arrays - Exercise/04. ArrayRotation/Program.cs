namespace _04._ArrayRotation
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int operations = int.Parse(Console.ReadLine());
            int[] newNumbers = new int[numbers.Length];

            for (int i = 0; i < operations; i++)
            {

                for (int k = 0; k < numbers.Length; k++)
                {

                    if (k == numbers.Length - 1)
                    {
                        int oldVar0 = numbers[0];
                        newNumbers[numbers.Length - 1] = oldVar0;
                    }
                    else
                    {
                        int oldVar = numbers[k + 1];
                        newNumbers[k] = oldVar;
                    }


                }

                Array.Copy(newNumbers, numbers, numbers.Length);
            }

            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }
        }
    }
}
