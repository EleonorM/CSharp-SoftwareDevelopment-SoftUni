namespace _10._Predicate_Party_
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<string, string, bool> startsWith = (n, param) => n.StartsWith(param);
            Func<string, string, bool> endsWith = (n, param) => n.EndsWith(param);
            Func<string, int, bool> length = (n, param) => n.Length == param;

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Party!")
                {
                    break;
                }

                if (input[0] == "Remove")
                {
                    if (input[1] == "StartsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (startsWith(people[i], input[2]))
                            {
                                people.Remove(people[i]);
                                i--;
                            }
                        }
                    }
                    else if (input[1] == "EndsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (endsWith(people[i], input[2]))
                            {
                                people.Remove(people[i]);
                                i--;
                            }
                        }
                    }
                    else if (input[1] == "Length")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (length(people[i], int.Parse(input[2])))
                            {
                                people.Remove(people[i]);
                                i--;
                            }
                        }
                    }
                }
                else if (input[0] == "Double")
                {
                    if (input[1] == "StartsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (startsWith(people[i], input[2]))
                            {
                                people.Insert(i, people[i]);
                                i++;
                            }
                        }
                    }
                    else if (input[1] == "EndsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (endsWith(people[i], input[2]))
                            {
                                people.Insert(i, people[i]);
                                i++;
                            }
                        }
                    }
                    else if (input[1] == "Length")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (length(people[i], int.Parse(input[2])))
                            {
                                people.Insert(i, people[i]);
                                i++;
                            }
                        }
                    }
                }
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
        }
    }
}
