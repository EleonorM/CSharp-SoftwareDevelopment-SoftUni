namespace _04.Bachelor_Party
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var sumForGuestEntertainer = int.Parse(Console.ReadLine());
            var couvert = 0;
            var sum = 0.0;
            var allPeople = 0;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "The restaurant is full")
                {
                    break;
                }
                var people = int.Parse(input);
                if (people < 5)
                {
                    couvert = 100;
                }
                else couvert = 70;
                allPeople += people;
                sum += people * couvert;
            }

            if (sum >= sumForGuestEntertainer)
            {
                Console.WriteLine($"You have {allPeople} guests and {sum - sumForGuestEntertainer} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {allPeople} guests and {sum} leva income, but no singer.");
            }
        }
    }
}
