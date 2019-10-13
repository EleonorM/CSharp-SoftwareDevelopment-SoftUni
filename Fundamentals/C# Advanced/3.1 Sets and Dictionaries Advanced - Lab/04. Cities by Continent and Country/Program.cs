namespace _04._Cities_by_Continent_and_Country
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();
            var totalRows = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalRows; i++)
            {
                var input = Console.ReadLine().Split();

                var continent = input[0];
                var country = input[1];
                var city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);
            }

            foreach (var continentKVp in continents)
            {
                var continentName = continentKVp.Key;
                var countryPRint = continentKVp.Value;

                Console.WriteLine($"{continentName}:");
                foreach (var countryKvp in countryPRint)
                {
                    var cities = countryKvp.Value;
                    Console.WriteLine($"  {countryKvp.Key} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
