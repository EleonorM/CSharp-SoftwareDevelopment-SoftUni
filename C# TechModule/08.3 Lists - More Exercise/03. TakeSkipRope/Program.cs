namespace _03._TakeSkipRope
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToCharArray();
            var numbers = new List<int>();
            var oddNumbers = new List<int>();
            var evenNumbers = new List<int>();
            var letters = new List<char>();
            var result = new List<char>();
            var counter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '0' && text[i] <= '9')
                {
                    numbers.Add(int.Parse((text[i]).ToString()));
                }
                else
                {
                    letters.Add(text[i]);
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenNumbers.Add(numbers[i]);
                }
                else
                {
                    oddNumbers.Add(numbers[i]);
                }
            }

            for (int i = 0; i < evenNumbers.Count; i++)
            {
                if (evenNumbers[i] > 0)
                {
                    for (int j = 0; j < evenNumbers[i]; j++)
                    {
                        if (counter < letters.Count)
                        {
                            result.Add(letters[counter]);
                        }

                        counter++;
                    }
                }

                if (oddNumbers[i] > 0 && oddNumbers.Count > i)
                {
                    counter += oddNumbers[i];
                }
            }

            foreach (var item in result)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }
    }
}
