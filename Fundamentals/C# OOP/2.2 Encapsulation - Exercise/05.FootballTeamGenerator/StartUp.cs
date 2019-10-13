namespace _05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class startUp
    {
        static void Main(string[] args)
        {

            var teams = new List<Team>();

            while (true)
            {
                var input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }
                try
                {
                    var teamName = input[1];
                    if (input[0].ToLower() == "team")
                    {
                        var team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (input[0].ToLower() == "add")
                    {
                        DoesTeamExist(teams, teamName);
                        var statsArray = input.Skip(3).Select(int.Parse).ToArray();
                        var stats = new Stats(statsArray[0], statsArray[1], statsArray[2], statsArray[3], statsArray[4]);
                        var player = new Player(input[2], stats);
                        teams.FirstOrDefault(x => x.Name == teamName).AddPlayer(player);

                    }
                    else if (input[0].ToLower() == "remove")
                    {
                        DoesTeamExist(teams, teamName);
                        var playerName = input[2];
                        teams.FirstOrDefault(x => x.Name == teamName).RemovePlayer(playerName);
                    }
                    else if (input[0].ToLower() == "rating")
                    {
                        DoesTeamExist(teams, teamName);

                        Console.WriteLine($"{teamName} - {teams.FirstOrDefault(x => x.Name == teamName).Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void DoesTeamExist(List<Team> teams, string teamName)
        {
            if (teams.FirstOrDefault(x => x.Name == teamName) == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}
