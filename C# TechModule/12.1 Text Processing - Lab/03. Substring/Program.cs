namespace _03._Substring
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var key = Console.ReadLine().ToLower();
            var word = Console.ReadLine();

            while (true)
            {
                var index = word.IndexOf(key);
                if (index == -1)
                {
                    break;
                }

                word = word.Remove(index, key.Length);
            }

            Console.WriteLine(word);
        }
    }
}
