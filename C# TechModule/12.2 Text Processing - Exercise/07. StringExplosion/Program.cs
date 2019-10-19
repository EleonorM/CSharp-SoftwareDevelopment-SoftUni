namespace _07._StringExplosion
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var count = 0;
            int number = 0;
            int left = 0;
            while (true)
            {
                var index = input.IndexOf('>', count + 1);
                if (index == -1)
                {
                    break;
                }

                count = index;
                number = input[index + 1] - '0';
                left += number;
                int leftFor = left;
                for (int i = 0; i < leftFor; i++)
                {
                    if (index + 1 >= input.Length || input[index + 1] == '>')
                    {
                        break;
                    }

                    input = input.Remove(index + 1, 1);
                    left--;
                }
            }

            Console.WriteLine(input);
        }
    }
}
