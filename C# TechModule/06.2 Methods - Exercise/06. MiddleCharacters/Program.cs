namespace _06._MiddleCharacters
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            PrintMiddleChar(input);
        }

        static void PrintMiddleChar(string input)
        {
            var inputChar = input.ToCharArray();
            if (inputChar.Length % 2 == 0)
            {
                Console.Write(inputChar[inputChar.Length / 2 - 1]);
            }

            Console.WriteLine(input[inputChar.Length / 2]);
        }
    }
}
