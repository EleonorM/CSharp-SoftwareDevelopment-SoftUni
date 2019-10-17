namespace _11._ThePartyReservationFM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var filters = new List<string>();

            while (true)
            {
                var input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Print")
                {
                    break;
                }
                else if (input[0] == "Add filter")
                {
                    filters.Add($"{input[1]};{input[2]}");
                }
                else if (input[0] == "Remove filter")
                {
                    filters.Remove($"{input[1]};{input[2]}");
                }
            }

            Func<string, string, bool> startsWithFilter = (str, param) => str.StartsWith(param);
            Func<string, string, bool> endsWithFilter = (str, param) => str.EndsWith(param);
            Func<string, int, bool> lenghtFilter = (str, lenght) => str.Length == lenght;
            Func<string, string, bool> containsFilter = (str, param) => str.Contains(param);

            foreach (var currentFilter in filters)
            {
                var currentFilterInfo = currentFilter.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var action = currentFilterInfo[0];
                var param = currentFilterInfo[1];

                if (action == "Starts with")
                {
                    names = names.Where(n => !startsWithFilter(n, param)).ToArray();
                }
                else if (action == "Ends with")
                {
                    names = names.Where(n => !endsWithFilter(n, param)).ToArray();
                }
                else if (action == "Lenght")
                {
                    names = names.Where(n => !lenghtFilter(n, int.Parse(param))).ToArray();
                }
                else if (action == "Contains")
                {
                    names = names.Where(n => !containsFilter(n, param)).ToArray();
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
