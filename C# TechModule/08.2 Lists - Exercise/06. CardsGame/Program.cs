namespace _06._CardsGame
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var firstDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondDeck = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                if (firstDeck.Count == 0 || secondDeck.Count == 0)
                {
                    break;
                }

                var firstFirstDeck = firstDeck[0];
                var firstSecondDeck = secondDeck[0];
                if (firstFirstDeck > firstSecondDeck)
                {
                    firstDeck.Add(firstFirstDeck);
                    firstDeck.Add(firstSecondDeck);
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
                else if (firstSecondDeck > firstFirstDeck)
                {
                    secondDeck.Add(firstSecondDeck);
                    secondDeck.Add(firstFirstDeck);
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
                else if (firstFirstDeck == firstSecondDeck)
                {
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
            }

            if (firstDeck.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstDeck.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondDeck.Sum()}");
            }
        }
    }
}
