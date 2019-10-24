namespace _04._Add_Minion
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                var searchedMinion = Console.ReadLine().Split().Skip(1).ToArray();
                var minionName = searchedMinion[0];
                var minionAge = int.Parse(searchedMinion[1]);
                var minionTown = searchedMinion[2];
                var searchedVillain = Console.ReadLine().Split().Skip(1).ToArray();
                var villainName = searchedVillain[0];

                var villainInfo = $"SELECT Id FROM Villains WHERE Name = @villainName";
                var minionInfo = $"SELECT Id FROM Minions WHERE Name = @minionName AND Age = @minionAge";

                var minionId = 0;
                var villainId = 0;

                using (var command = new SqlCommand(minionInfo, connection))
                {
                    command.Parameters.AddWithValue("@minionName", minionName);
                    command.Parameters.AddWithValue("@minionAge", minionName);
                    using SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           minionId = (int)reader[0];
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No minion with Name {minionName} and Age {minionAge} exists in the database.");
                        return;
                    }
                }

                using (var command = new SqlCommand(villainInfo, connection))
                {
                    command.Parameters.AddWithValue("@villainName", villainName);

                    using SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        villainId = (int)reader[0];
                    }
                    else
                    {
                        var insertVillain = $"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES ({villainName}, 4)";

                        using (var commandInsert = new SqlCommand(insertVillain, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        Console.WriteLine($"Villain {villainName} inserted into database!");
                    }
                }

                var insertIntoVillainsMinions = $"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

                using (var command = new SqlCommand(insertIntoVillainsMinions, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    command.Parameters.AddWithValue("@minionId", minionId);
                    command.ExecuteNonQuery();
                }



                var insertMinion= $"INSERT INTO Minions(Name, Age, TownId) VALUES({minionName}, {minionAge}, {minionTown})";

                using (var command = new SqlCommand(insertMinion, connection))
                {
                    command.ExecuteNonQuery();
                }


                connection.Close();
            }
        }
    }
}
