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

                var minionId = 0;
                var villainId = 0;
                var townId = 0;

                var minionInfo = $"SELECT Id FROM Minions WHERE Name = @minionName AND Age = @minionAge";
                using (var command = new SqlCommand(minionInfo, connection))
                {
                    command.Parameters.AddWithValue("@minionName", minionName);
                    command.Parameters.AddWithValue("@minionAge", minionAge);
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

                var villainInfo = $"SELECT Id FROM Villains WHERE Name = @villainName";
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
                        reader.Close();
                        var insertVillain = $"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

                        using (var commandInsert = new SqlCommand(insertVillain, connection))
                        {
                            commandInsert.Parameters.AddWithValue("@villainName", villainName);
                            commandInsert.ExecuteNonQuery();
                        }

                        Console.WriteLine($"Villain {villainName} inserted into database!");

                        using SqlDataReader reader2 = command.ExecuteReader();
                        reader2.Read();
                        villainId = (int)(reader2[0]);
                    }
                }


                var insertIntoVillainsMinions = $"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
                using (var command = new SqlCommand(insertIntoVillainsMinions, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    command.Parameters.AddWithValue("@minionId", minionId);
                    command.ExecuteNonQuery();
                }


                var townInfo = $"SELECT Id FROM Towns WHERE Name = @townName";
                using (var command = new SqlCommand(townInfo, connection))
                {
                    command.Parameters.AddWithValue("@townName", minionTown);

                    using SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        townId = (int)reader[0];
                    }
                    else
                    {
                        reader.Close();
                        var insertTown = $"INSERT INTO Towns (Name) VALUES (@townName2)";

                        using (var commandInsert = new SqlCommand(insertTown, connection))
                        {
                            commandInsert.Parameters.AddWithValue("@townName2", minionTown);
                            commandInsert.ExecuteNonQuery();
                        }

                        Console.WriteLine($"Town {minionTown} was added to the database.");

                        using SqlDataReader reader2 = command.ExecuteReader();
                        reader2.Read();
                        townId = (int)(reader2[0]);
                    }
                }


                var insertMinion = $"INSERT INTO Minions(Name, Age, TownId) VALUES(@name, @age, @townId)";
                using (var command = new SqlCommand(insertMinion, connection))
                {
                    command.Parameters.AddWithValue("@name", minionName);
                    command.Parameters.AddWithValue("@age", minionAge);
                    command.Parameters.AddWithValue("@townId", townId);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }

                connection.Close();
            }
        }
    }
}
