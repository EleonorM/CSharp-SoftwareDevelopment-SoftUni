namespace _05._MultiplyBigNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray().Select(x => (int)(x - '0')).ToList();
            var number = int.Parse(Console.ReadLine());
            if ((input.Count == 1 && input[0] == 0) || number == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {
                while (input[0] == 0)
                {
                    input.Remove(0);
                }
            }

            var result = new List<int>();
            var leftNumber = 0;
            for (int i = input.Count - 1; i >= 0; i--)
            {
                int numberInput = input[i];
                var sum = number * numberInput + leftNumber;
                leftNumber = 0;
                if (sum > 9)
                {
                    leftNumber = sum / 10;
                    result.Insert(0, sum % 10);
                }
                else
                    result.Insert(0, sum);
                if (i == 0 && leftNumber != 0)
                {
                    result.Insert(0, leftNumber);
                }
            }

            Console.WriteLine(string.Concat(result));
        }
    }
}
