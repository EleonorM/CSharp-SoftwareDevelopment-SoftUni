namespace _06._RemoveVillain
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
                var searchedVillainId = int.Parse(Console.ReadLine());
                var villanInfo = "SELECT Name FROM Villains WHERE Id = @villainId";
                using var command = new SqlCommand(villanInfo, connection);
                command.Parameters.AddWithValue("@villainId", searchedVillainId);

                var villainName = string.Empty;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No such villain was found");
                        return;
                    }
                    else
                    {
                        reader.Read();
                        villainName = (string)reader[0];
                    }
                }

                var deletedMinions = 0;

                var deleteFromVillainMinon = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                using (var commandDeleteFromVillainMinion = new SqlCommand(deleteFromVillainMinon, connection))
                {
                    commandDeleteFromVillainMinion.Parameters.AddWithValue("@villainId", searchedVillainId);
                    deletedMinions = commandDeleteFromVillainMinion.ExecuteNonQuery();
                    Console.WriteLine($"{villainName} was deleted.");
                }

                var deleteFromVillain = "DELETE FROM Villains WHERE Id = @villainId";
                using (var commandDeleteFromVillain = new SqlCommand(deleteFromVillain, connection))
                {
                    commandDeleteFromVillain.Parameters.AddWithValue("@villainId", searchedVillainId);
                    commandDeleteFromVillain.ExecuteNonQuery();
                    Console.WriteLine($"{deletedMinions} minions were released.");
                }

                connection.Close();
            }
        }
    }
}
