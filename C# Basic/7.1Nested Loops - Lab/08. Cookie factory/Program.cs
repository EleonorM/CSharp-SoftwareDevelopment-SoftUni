namespace _08.Cookie_factory
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var batch = int.Parse(Console.ReadLine());
            for (int i = 1; i <= batch; i++)
            {
                var products = Console.ReadLine();
                var eggs = 0;
                var flour = 0;
                var sugar = 0;
                while (true)
                {
                    switch (products)
                    {
                        case "eggs":
                            eggs++; break;
                        case "flour":
                            flour++; break;
                        case "sugar":
                            sugar++; break;
                        default:
                            break;
                    }

                    if (products == "Bake!" && eggs > 0 && flour > 0 && sugar > 0)
                    {
                        Console.WriteLine($"Baking batch number {i}...");
                        break;
                    }
                    else if (products == "Bake!")
                    {
                        Console.WriteLine($"The batter should contain flour, eggs and sugar!");
                    }

                    products = Console.ReadLine();
                }
            }
        }
    }
}
