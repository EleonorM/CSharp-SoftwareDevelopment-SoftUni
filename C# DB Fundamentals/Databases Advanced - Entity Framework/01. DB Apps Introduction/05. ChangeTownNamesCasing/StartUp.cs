namespace _05._ChangeTownNamesCasing
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

                var countryName = Console.ReadLine();
                var updateCountryName = $"UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                using (var command = new SqlCommand(updateCountryName, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    var changed = command.ExecuteNonQuery();
                    if (changed == 0)
                    {
                        Console.WriteLine($"No town names were affected.");
                    }
                    else
                    {
                        Console.WriteLine($"{changed} town names were affected.");

                        var townsInfo = "SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName";
                        using SqlCommand command1 = new SqlCommand(townsInfo, connection);
                        command1.Parameters.AddWithValue("@countryName", countryName);
                        using SqlDataReader reader = command1.ExecuteReader();

                        var townsChanged = new List<object>();
                        while (reader.Read())
                        {
                            var numb = new Object[reader.FieldCount];

                            reader.GetValues(numb);

                            townsChanged.Add(numb[0]);
                        }

                        Console.WriteLine($"[{string.Join(",", townsChanged)}]");
                    }
                }

                connection.Close();
            }
        }
    }
}
