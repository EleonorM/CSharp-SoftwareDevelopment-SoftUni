namespace _05._Teamwork_projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Team
        {
            public string TeamName;

            public string Creator { get; set; }

            public List<string> Members { get; set; }

            public Team()
            {
                Members = new List<string>();
            }

        }
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var teams = new List<Team>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split("-");
                var creator = input[0];
                var club = input[1];
                var team = new Team();
                if (teams.Exists(e => e.TeamName == club))
                {
                    Console.WriteLine($"Team {club} was already created!");
                    continue;
                }

                if (teams.Exists(e => e.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                team.Creator = creator;
                team.TeamName = club;
                teams.Add(team);
                Console.WriteLine($"Team {team.TeamName} has been created by {team.Creator}!");
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end of assignment")
                {
                    break;
                }

                string[] inputParts = input.Split("->").ToArray();
                string member = inputParts[0];
                string club = inputParts[1];

                var team = teams.Find(f => f.TeamName == club);
                if (team == null)
                {
                    Console.WriteLine($"Team {club} does not exist!");
                    continue;
                }

                if ((teams.Exists(f => f.Members.Count > 0) && teams.Exists(f => f.Members.Contains(member))) || teams.Exists(f => f.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {club}!");
                    continue;
                }

                var index = teams.IndexOf(team);
                teams[index].Members.Add(member);
            }

            teams = teams.OrderBy(o => o.Members.Count).Reverse().ToList();
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].Members.Sort();
            }

            //teams = teams.OrderBy(o => o.Members).Reverse().ToList();
            foreach (var team in teams)
            {
                if (team.Members.Count != 0)
                {
                    Console.WriteLine(team.TeamName);
                    Console.WriteLine($"- {team.Creator}");
                    foreach (var member in team.Members)
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }

            Console.WriteLine("Teams to disband:");
            var teamToDisband = new List<string>();
            foreach (var team in teams)
            {
                if (team.Members.Count == 0)
                {
                    teamToDisband.Add(team.TeamName);
                }
            }

            teamToDisband.Sort();
            foreach (var item in teamToDisband)
            {
                Console.WriteLine(item);
            }
        }
    }
}
