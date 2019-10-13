namespace _02.Maiden_Party
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var loveLetter = 0.6;
            var rose = 7.2;
            var keychain = 3.6;
            var drawing = 18.2;
            var surprise = 22.0;

            var maidenPartyPrice = double.Parse(Console.ReadLine());
            var loveLettersCount = int.Parse(Console.ReadLine());
            var roseCount = int.Parse(Console.ReadLine());
            var keychainCount = int.Parse(Console.ReadLine());
            var drawingCount = int.Parse(Console.ReadLine());
            var surpriseCount = int.Parse(Console.ReadLine());

            var sum = loveLettersCount * loveLetter + roseCount * rose + keychainCount * keychain + drawingCount * drawing + surpriseCount * surprise;
            if (loveLettersCount + roseCount + keychainCount + drawingCount + surpriseCount > 24)
            {
                sum = 0.65 * sum;
            }

            var result = sum * 0.9;
            if (result >= maidenPartyPrice)
            {
                Console.WriteLine($"Yes! {result - maidenPartyPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {maidenPartyPrice - result:f2} lv needed.");
            }
        }
    }
}
