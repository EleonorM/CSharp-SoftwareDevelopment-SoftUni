namespace _01._ValidUsernames
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ");

            for (int i = 0; i < input.Length; i++)
            {
                var word = input[i].ToCharArray();
                var isValid = true;

                for (int j = 0; j < word.Length; j++)
                {

                    if (char.IsLetter(word[j]) || char.IsDigit(word[j]) || word[j] == '-' || word[j] == '_')
                    {

                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid && input[i].Length > 2 && input[i].Length < 16)
                {
                    Console.WriteLine(input[i]);
                }
            }
        }
    }
}
