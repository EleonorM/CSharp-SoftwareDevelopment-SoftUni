namespace _05._Dragon_Army
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static void Main(string[] args)
        {
            var players = new Dictionary<string, SortedDictionary<string, Stats>>();
            var rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split();
                var type = input[0];
                var name = input[1];
                var damage = 0;
                var health = 0;
                var armor = 0;
                if (input[2] == "null")
                {
                    damage = 45;
                }
                else
                    damage = int.Parse(input[2]);
                if (input[3] == "null")
                {
                    health = 250;
                }
                else
                    health = int.Parse(input[3]);
                if (input[4] == "null")
                {
                    armor = 10;
                }
                else
                    armor = int.Parse(input[4]);

                if (!players.ContainsKey(type))
                {
                    players[type] = new SortedDictionary<string, Stats>();
                    players[type][name] = new Stats
                    {
                        Health = health,
                        Damage = damage,
                        Armor = armor
                    };
                }
                else
                {
                    if (players[type].ContainsKey(name))
                    {
                        players[type][name].Armor = armor;
                        players[type][name].Damage = damage;
                        players[type][name].Health = health;
                    }
                    else
                    {
                        players[type][name] = new Stats
                        {
                            Health = health,
                            Damage = damage,
                            Armor = armor
                        };
                    }
                }
            }

            var allStats = new Dictionary<string, Stats>();

            foreach (var kvp in players)
            {
                foreach (var value in kvp.Value)
                {
                    if (allStats.ContainsKey(kvp.Key))
                    {
                        allStats[kvp.Key].Armor += value.Value.Armor;
                        allStats[kvp.Key].Health += value.Value.Health;
                        allStats[kvp.Key].Damage += value.Value.Damage;
                    }
                    else
                    {
                        allStats[kvp.Key] = new Stats
                        {
                            Health = value.Value.Health,
                            Damage = value.Value.Damage,
                            Armor = value.Value.Armor
                        };
                    }
                }
            }

            foreach (var kvp in players)
            {
                Console.WriteLine($"{kvp.Key}::({allStats[kvp.Key].Damage * 1.0 / kvp.Value.Count:f2}/{allStats[kvp.Key].Health * 1.0 / kvp.Value.Count:f2}/{allStats[kvp.Key].Armor * 1.0 / kvp.Value.Count:f2})");
                foreach (var value in kvp.Value)
                {
                    Console.WriteLine($"-{value.Key} -> damage: {value.Value.Damage}, health: {value.Value.Health}, armor: {value.Value.Armor}");
                }
            }
        }

        public class Stats
        {
            public int Damage { get; set; }

            public int Health { get; set; }

            public int Armor { get; set; }
        }
    }
}
