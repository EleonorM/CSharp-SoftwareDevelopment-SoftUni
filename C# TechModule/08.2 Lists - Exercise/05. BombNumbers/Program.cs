namespace _05._BombNumbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            var bombNumber = input[0];
            var power = input[1];

            var index = numbers.IndexOf(bombNumber);
            while (index >= 0)
            {
                for (int i = 0; i < power; i++)
                {
                    if (index - 1 >= 0)
                    {
                        numbers.RemoveAt(index - 1);
                        index -= 1;
                    }

                    if (index + 1 <= numbers.Count - 1)
                    {
                        numbers.RemoveAt(index + 1);
                    }
                }

                numbers.RemoveAt(index);
                index = numbers.IndexOf(bombNumber);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
