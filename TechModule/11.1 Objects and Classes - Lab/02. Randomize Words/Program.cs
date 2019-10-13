namespace _02.Randomize_Words
{
    using System;
    using System.Linq;

    public class Program
    {
        private static void Main()
        {
            var sentence = Console.ReadLine().Split().ToList();
            var rnd = new Random();
            for (int i = 0; i < sentence.Count; i++)
            {
                var ri = rnd.Next(0, sentence.Count);

                var current = sentence[i];
                sentence[i] = sentence[ri];
                sentence[ri] = current;
            }

            foreach (var item in sentence)
            {
                Console.WriteLine(item);
            }
        }
    }
}
