namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                 .Movies
                 //.Where(x => x.Rating >= rating && x.Projections.Any(p=>p.Tickets.Count>0))
                 .Select(x => new
                 {
                     MovieName = x.Title,
                     Rating = $"{x.Rating:f2}",
                     TotalIncomes = $"{x.Projections.Sum(y => y.Tickets.Sum(t => t.Price)):f2}",
                     Customers = x.Projections.Select(t => new
                     {
                         FirstName = t.Tickets.Select(p => p.Customer.FirstName),
                         //LastName = t.Customer.LastName,
                         //Balance = $"{t.Customer.Balance:f2}"
                     })
                     //.OrderByDescending(c => c.Balance)
                     //.ThenBy(c => c.FirstName)
                     //.ThenBy(c => c.LastName)
                     .ToArray()

                 })
                 .ToArray()
                 .OrderByDescending(m => m.Rating, new SemiNumericComparer())
                 .ThenByDescending(m => m.TotalIncomes, new SemiNumericComparer())
                //.Take(10)
                 .ToArray();

            var jsonResult = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public class SemiNumericComparer : IComparer<string>
        {
            /// <summary>
            /// Method to determine if a string is a number
            /// </summary>
            /// <param name="value">String to test</param>
            /// <returns>True if numeric</returns>
            public static bool IsNumeric(string value)
            {
                return int.TryParse(value, out _);
            }

            /// <inheritdoc />
            public int Compare(string s1, string s2)
            {
                const int S1GreaterThanS2 = 1;
                const int S2GreaterThanS1 = -1;

                var IsNumeric1 = IsNumeric(s1);
                var IsNumeric2 = IsNumeric(s2);

                if (IsNumeric1 && IsNumeric2)
                {
                    var i1 = Convert.ToInt32(s1);
                    var i2 = Convert.ToInt32(s2);

                    if (i1 > i2)
                    {
                        return S1GreaterThanS2;
                    }

                    if (i1 < i2)
                    {
                        return S2GreaterThanS1;
                    }

                    return 0;
                }

                if (IsNumeric1)
                {
                    return S2GreaterThanS1;
                }

                if (IsNumeric2)
                {
                    return S1GreaterThanS2;
                }

                return string.Compare(s1, s2, true, CultureInfo.InvariantCulture);
            }
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            throw new NotImplementedException();
        }
    }
}