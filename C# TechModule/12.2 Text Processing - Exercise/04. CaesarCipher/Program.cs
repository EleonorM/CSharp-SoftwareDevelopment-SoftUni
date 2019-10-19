namespace _04._CaesarCipher
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var result = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[i] = (char)(input[i] + 3);
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
