namespace _03._MinionNames
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var givenId = int.Parse(Console.ReadLine());
                var villanName = $"SELECT Name FROM Villains WHERE Id = @givenId";
                var minionsInfo = $"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum, m.Name, m.Age FROM MinionsVillains AS mv JOIN Minions As m ON mv.MinionId = m.Id WHERE mv.VillainId = @givenId ORDER BY m.Name";

                using (var command = new SqlCommand(villanName, connection))
                {
                    command.Parameters.AddWithValue("givenId", givenId);
                    using SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Villan: {reader[0]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {givenId} exists in the database.");
                        return;
                    }
                }

                using (var command = new SqlCommand(minionsInfo, connection))
                {
                    using SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"(no minions)");
                    }
                }

                connection.Close();
            }
        }
    }
}
