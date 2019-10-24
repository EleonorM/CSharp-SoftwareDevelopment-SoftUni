namespace _08._IncreaseMinionAge
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
                var ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var updateCommand = " UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 WHERE Id IN (@Id)";

                foreach (var id in ids)
                {
                    using var command = new SqlCommand(updateCommand, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                

                var minionsInfo = "SELECT Name, Age FROM Minions";
                using var commandRead = new SqlCommand(minionsInfo, connection);
                using SqlDataReader reader = commandRead.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }

                connection.Close();
            }
        }
    }
}
