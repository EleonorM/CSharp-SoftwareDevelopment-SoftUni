namespace _5._Supermarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Queue<string> queuePeople = new Queue<string>();
            var input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Paid")
                {
                    string currentPerson;
                    while (queuePeople.Any())
                    {
                        currentPerson = queuePeople.Dequeue();
                        Console.WriteLine(currentPerson);
                    }
                }
                else
                {
                    queuePeople.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{queuePeople.Count} people remaining.");
        }
    }
}
