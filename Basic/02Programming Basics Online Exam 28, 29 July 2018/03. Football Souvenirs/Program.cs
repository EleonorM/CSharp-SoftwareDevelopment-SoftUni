namespace _03.Football_Souvenirs
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var team = Console.ReadLine();
            var typeSouvenir = Console.ReadLine();
            var counts = int.Parse(Console.ReadLine());
            double price;
            if (team == "Argentina")
            {
                switch (typeSouvenir)
                {
                    case "flags": price = 3.25; break;
                    case "caps": price = 7.2; break;
                    case "posters": price = 5.1; break;
                    case "stickers": price = 1.25; break;
                    default:
                        Console.WriteLine("Invalid stock!");
                        return;
                }
            }
            else if (team == "Brazil")
            {
                switch (typeSouvenir)
                {
                    case "flags": price = 4.2; break;
                    case "caps": price = 8.5; break;
                    case "posters": price = 5.35; break;
                    case "stickers": price = 1.2; break;
                    default:
                        Console.WriteLine("Invalid stock!");
                        return;
                }
            }
            else if (team == "Croatia")
            {
                switch (typeSouvenir)
                {
                    case "flags": price = 2.75; break;
                    case "caps": price = 6.9; break;
                    case "posters": price = 4.95; break;
                    case "stickers": price = 1.1; break;
                    default:
                        Console.WriteLine("Invalid stock!");
                        return;
                }
            }
            else if (team == "Denmark")
            {
                switch (typeSouvenir)
                {
                    case "flags": price = 3.1; break;
                    case "caps": price = 6.5; break;
                    case "posters": price = 4.8; break;
                    case "stickers": price = 0.9; break;
                    default:
                        Console.WriteLine("Invalid stock!");
                        return;
                }
            }
            else
            {
                Console.WriteLine("Invalid country!");
                return;
            }

            Console.WriteLine($"Pepi bought {counts} {typeSouvenir} of {team} for {price * counts:f2} lv.");
        }
    }
}
