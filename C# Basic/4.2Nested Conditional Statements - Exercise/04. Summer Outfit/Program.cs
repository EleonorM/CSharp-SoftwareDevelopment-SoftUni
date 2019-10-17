namespace _04.Summer_Outfit
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var degrees = int.Parse(Console.ReadLine());
            var daytime = Console.ReadLine().ToLower();
            var outfit = "";
            var shoes = "";

            if (10 <= degrees && degrees <= 18)
            {
                if (daytime == "morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (daytime == "afternoon")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (daytime == "evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (18 < degrees && degrees <= 24)
            {
                if (daytime == "morning")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (daytime == "afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (daytime == "evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (24 < degrees)
            {
                if (daytime == "morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (daytime == "afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (daytime == "evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }

            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
