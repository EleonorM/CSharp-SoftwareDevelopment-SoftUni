namespace _09._PokemonDon_tGo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var removedElements = new List<int>();

            while (true)
            {
                if (elements.Count == 0)
                {
                    break;
                }
                var index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    var removedNumber = elements[0];
                    removedElements.Add(removedNumber);
                    elements.RemoveAt(0);
                    for (int i = 0; i < elements.Count; i++)
                    {
                        if (elements[i] <= removedNumber)
                        {
                            elements[i] = elements[i] + removedNumber;
                        }
                        else
                        {
                            elements[i] = elements[i] - removedNumber;
                        }
                    }

                    elements.Insert(0, elements[elements.Count - 1]);
                }
                else if (index >= elements.Count)
                {
                    var removedNumber = elements[elements.Count - 1];
                    removedElements.Add(removedNumber);
                    elements.RemoveAt(elements.Count - 1);
                    for (int i = 0; i < elements.Count; i++)
                    {
                        if (elements[i] <= removedNumber)
                        {
                            elements[i] = elements[i] + removedNumber;
                        }
                        else
                        {
                            elements[i] = elements[i] - removedNumber;
                        }
                    }

                    elements.Insert(elements.Count, elements[0]);
                }
                else
                {
                    var removedNumber = elements[index];
                    removedElements.Add(removedNumber);
                    elements.RemoveAt(index);
                    for (int i = 0; i < elements.Count; i++)
                    {
                        if (elements[i] <= removedNumber)
                        {
                            elements[i] = elements[i] + removedNumber;
                        }
                        else
                        {
                            elements[i] = elements[i] - removedNumber;
                        }
                    }
                }
            }

            Console.WriteLine(removedElements.Sum());
        }
    }
}
