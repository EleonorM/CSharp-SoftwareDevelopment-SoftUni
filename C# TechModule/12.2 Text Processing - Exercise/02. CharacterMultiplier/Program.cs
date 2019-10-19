namespace _02._CharacterMultiplier
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var word1 = input[0].ToCharArray();
            var word2 = input[1].ToCharArray();
            var sum = 0;
            for (int i = 0; i < Math.Min(word1.Length, word2.Length); i++)
            {
                sum += word2[i] * word1[i];
            }

            var longestWord = new char[Math.Max(word1.Length, word2.Length)];
            if (word1.Length == longestWord.Length)
            {
                longestWord = word1;
            }
            else
            {
                longestWord = word2;
            }

            for (int i = Math.Min(word1.Length, word2.Length); i < longestWord.Length; i++)
            {
                sum += longestWord[i];
            }

            Console.WriteLine(sum);
        }
    }
}
