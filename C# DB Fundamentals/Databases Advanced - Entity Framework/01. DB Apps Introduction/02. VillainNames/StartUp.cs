namespace _02._VillainNames
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
                var villanInfo = "SELECT Name, COUNT(mv.MinionId) AS MinionsCount FROM Villains AS v JOIN  MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Name HAVING COUNT(mv.MinionId) >= 3 ORDER BY MinionsCount DESC";

                using (var command = new SqlCommand(villanInfo, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]}");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
