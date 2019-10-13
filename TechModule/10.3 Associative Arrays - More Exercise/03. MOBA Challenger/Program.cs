namespace _03._MOBA_Challenger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static void Main()
        {
            var players = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Season end")
                {
                    break;
                }

                try
                {
                    var tokens = input.Split(" -> ");
                    var player = tokens[0];
                    var possition = tokens[1];
                    var skill = int.Parse(tokens[2]);

                    if (players.ContainsKey(player))
                    {
                        if (players[player].ContainsKey(possition))
                        {
                            if (players[player][possition] < skill)
                            {
                                players[player][possition] = skill;
                            }
                        }
                        else
                        {
                            players[player][possition] = skill;
                        }
                    }
                    else
                    {
                        players[player] = new Dictionary<string, int>();
                        players[player][possition] = skill;
                    }
                }
                catch
                {
                }

                try
                {
                    var tokens = input.Split(" vs ");
                    var player1 = tokens[0];
                    var player2 = tokens[1];

                    if (players.ContainsKey(player2) && players.ContainsKey(player1))
                    {
                        bool isTrue = false;

                        foreach (var kvp in players[player1])
                        {
                            foreach (var item in players[player2])
                            {
                                if (kvp.Key == item.Key)
                                {
                                    isTrue = true;
                                }
                            }
                        }

                        var battle = new Dictionary<string, int>();

                        if (isTrue)
                        {
                            battle[player1] = 0;
                            battle[player2] = 0;

                            foreach (var kvp in players[player1])
                            {
                                battle[player1] += kvp.Value;
                            }

                            foreach (var kvp in players[player2])
                            {
                                battle[player2] += kvp.Value;
                            }

                            if (battle[player1] > battle[player2])
                            {
                                players.Remove(player2);
                            }
                            else if (battle[player1] < battle[player2])
                            {
                                players.Remove(player1);
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            players = players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);
            foreach (var kvp in players)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");
                var dict = kvp.Value;
                dict = dict.OrderByDescending(x => x.Value).ThenBy(y => y.Key).ToDictionary(k => k.Key, v => v.Value);
                foreach (var item in dict)
                {
                    Console.WriteLine($"- {item.Key} <::> {item.Value}");
                }
            }
        }
    }
}
