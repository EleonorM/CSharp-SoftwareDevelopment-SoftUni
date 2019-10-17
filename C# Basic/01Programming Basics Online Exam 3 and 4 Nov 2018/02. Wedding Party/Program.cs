namespace _02.Wedding_Party
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var guests = int.Parse(Console.ReadLine());
            var budget = int.Parse(Console.ReadLine());

            var couvert = guests * 20;
            if (couvert <= budget)
            {
                var fireworks = 0.4 * (budget - couvert);
                Console.WriteLine($"Yes! {fireworks:f0} lv are for fireworks and {budget - couvert - fireworks:f0} lv are for donation.");
            }
            else
            {
                Console.WriteLine($"They won't have enough money to pay the covert. They will need {couvert - budget} lv more.");
            }
        }
    }
}
