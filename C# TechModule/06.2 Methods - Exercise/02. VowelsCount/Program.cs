namespace _02._VowelsCount
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (IsVowel(input[i]))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
        static bool IsVowel(this char character)
        {
            return new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' }.Contains(char.ToLower(character));
        }
    }
}
