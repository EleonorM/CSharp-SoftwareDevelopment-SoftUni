namespace _09._IncreaseAgeStoredProcedure
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                var searchedMinionId = int.Parse(Console.ReadLine());

                using (var command = new SqlCommand("usp_GetOlder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", searchedMinionId);

                    if (command.ExecuteNonQuery() != 0)
                    {
                        var minionInfo = "SELECT Name, Age FROM Minions WHERE Id = @Id";
                        using var command1 = new SqlCommand(minionInfo, connection);
                        command1.Parameters.AddWithValue("@Id", searchedMinionId);
                        using SqlDataReader reader = command1.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} – {reader[1]} years old");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
