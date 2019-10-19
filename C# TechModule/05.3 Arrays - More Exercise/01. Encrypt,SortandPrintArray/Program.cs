namespace _01._Encrypt_SortandPrintArray
{
    using System;
    using System.Linq;

    static class Program
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var result = new int[lines];
            for (int i = 0; i < lines; i++)
            {
                var sum = 0;
                var name = Console.ReadLine().ToCharArray();
                for (int j = 0; j < name.Length; j++)
                {
                    if (IsVowel(name[j]))
                    {
                        sum += name[j] * name.Length;
                    }
                    else
                    {
                        sum += name[j] / name.Length;
                    }
                }
                result[i] = sum;
            }
            Array.Sort(result);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static bool IsVowel(this char character)
        {
            return new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' }.Contains(char.ToLower(character));
        }
    }
}
