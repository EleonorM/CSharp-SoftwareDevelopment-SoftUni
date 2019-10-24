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

                var minions = new List<object>();
                while (reader.Read())
                {
                    var numb = new Object[reader.FieldCount];

                    reader.GetValues(numb);

                    minions.Add(numb[0]);
                }
            }
        }
    }
}
