namespace _01._EventsInGivenDateRange
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            var linesToRead = int.Parse(Console.ReadLine());


            var collectionOfCoursesAndDates = new OrderedMultiDictionary<DateTime, string>(true);
            for (int i = 0; i < linesToRead; i++)
            {
                var courseAndDate = Console.ReadLine().Split(" | ");
                var course = courseAndDate[0];
                var date = DateTime.Parse(courseAndDate[1]);
                collectionOfCoursesAndDates.Add(date, course);
            }

            var linesToReadRange = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesToReadRange; i++)
            {
                var fromDateAndToDate = Console.ReadLine().Split(" | ");
                var fromDate = DateTime.Parse(fromDateAndToDate[0]);
                var toDate = DateTime.Parse(fromDateAndToDate[1]);
                var eventsInRange = collectionOfCoursesAndDates.Range(fromDate, true, toDate, true);
                Console.WriteLine(eventsInRange.Values.Count);
                foreach (var eventInRange in eventsInRange)
                {
                    if (eventInRange.Value.Count > 1)
                    {
                        foreach (var eventValue in eventInRange.Value)
                        {
                            Console.WriteLine($"{eventValue} | {eventInRange.Key:dd-MMM-yyyy}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{eventInRange.Value.First()} | {eventInRange.Key:dd-MMM-yyyy}");
                    }
                }
            }
        }
    }
}
