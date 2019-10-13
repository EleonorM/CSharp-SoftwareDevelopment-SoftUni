namespace _09.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Tournament")
                {
                    break;
                }

                var pockemon = new Pokemon { Name = input[1], Element = input[2], Health = int.Parse(input[3]) };
                var trainerName = input[0]; ;
                if (trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName].CollectionOfPockemons.Add(pockemon);
                }
                else
                {
                    var trainer = new Trainer { Name = input[0], NumberOfBadges = 0 };
                    trainer.CollectionOfPockemons.Add(pockemon);
                    trainers[trainer.Name] = trainer;
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Value.CollectionOfPockemons.FirstOrDefault(x => x.Element == input) != null)
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        var collection = trainer.Value.CollectionOfPockemons;
                        try
                        {
                            foreach (var pockemon in collection)
                            {
                                pockemon.Health -= 10;
                                if (pockemon.Health <= 0)
                                {
                                    trainer.Value.CollectionOfPockemons.Remove(pockemon);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }

            trainers = trainers.OrderByDescending(x => x.Value.NumberOfBadges).ToDictionary(k => k.Key, v => v.Value);
            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.NumberOfBadges} {trainer.Value.CollectionOfPockemons.Count}");
            }
        }
    }
}
