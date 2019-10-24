namespace _07._PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var minonsInfo = "SELECT Name FROM Minions";
                using var command = new SqlCommand(minonsInfo, connection);
                using SqlDataReader reader = command.ExecuteReader();

                var minions = new List<string>();
                while (reader.Read())
                {
                    var name = (string)reader[0];

                    minions.Add(name);
                }

                if (minions.Count > 0)
                {
                    for (int i = 0; i < minions.Count / 2; i++)
                    {
                        Console.WriteLine(minions[i]);
                        Console.WriteLine(minions[minions.Count - 1 - i]);
                    }

                    if (minions.Count % 2 != 0)
                    {
                        Console.WriteLine(minions[minions.Count / 2]);
                    }
                }
            }
        }
    }
}
