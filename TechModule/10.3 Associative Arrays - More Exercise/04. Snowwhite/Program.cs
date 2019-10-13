namespace _04._Snowwhite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static void Main(string[] args)
        {
            var dwarfs = new Dictionary<int, Dictionary<string, List<string>>>();

            while (true)
            {
                var input = Console.ReadLine().Split(new string[] { "<", ":", ">", " " }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Once")
                {
                    break;
                }

                var name = input[0];
                var colorHat = input[1];
                var physics = int.Parse(input[2]);
                var removeColorHat = false;
                var removePhysics = false;
                int physicsToRemove = 0;
                var terminate = false;
                foreach (var kvp in dwarfs)
                {
                    foreach (var value in kvp.Value)
                    {
                        if (value.Key == colorHat && value.Value.Contains(name) && kvp.Key < physics)
                        {
                            dwarfs[kvp.Key][colorHat].Remove(name);
                            if (dwarfs[kvp.Key][colorHat].Count() == 0)
                            {
                                if (dwarfs[kvp.Key].Count() == 0)
                                {
                                    removePhysics = true;
                                    physicsToRemove = kvp.Key;
                                    break;
                                }

                                removeColorHat = true;
                                physicsToRemove = kvp.Key;
                            }
                        }
                        else if (value.Key == colorHat && value.Value.Contains(name) && kvp.Key >= physics)
                        {
                            terminate = true;
                            break;
                        }
                    }
                    if (terminate)
                    {
                        continue;
                    }

                    if (removePhysics)
                    {
                        dwarfs.Remove(physicsToRemove);
                    }
                    else if (removeColorHat)
                    {
                        dwarfs[physicsToRemove].Remove(colorHat);
                    }
                }
                if (terminate)
                {
                   continue;
                }

                if (dwarfs.ContainsKey(physics))
                {
                    if (!dwarfs[physics].ContainsKey(colorHat))
                    {
                        dwarfs[physics][colorHat] = new List<string>();
                        dwarfs[physics][colorHat].Add(name);
                    }
                    else if (!dwarfs[physics][colorHat].Contains(name))
                    {
                        dwarfs[physics][colorHat].Add(name);
                    }
                }
                else
                {
                    dwarfs[physics] = new Dictionary<string, List<string>>();
                    dwarfs[physics][colorHat] = new List<string>();
                    dwarfs[physics][colorHat].Add(name);
                }
            }

            dwarfs = dwarfs.OrderByDescending(x => x.Key).ToDictionary(k => k.Key, v => v.Value);

            var colorCount = new Dictionary<string, int>();
            foreach (var kvp in dwarfs)
            {
                foreach (var value in kvp.Value)
                {
                    if (colorCount.ContainsKey(value.Key))
                    {
                        colorCount[value.Key] += value.Value.Count();
                    }
                    else
                    {
                        colorCount[value.Key] = value.Value.Count();
                    }
                }
            }

            colorCount = colorCount.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
            foreach (var kvp in dwarfs)
            {
                Dictionary<string, List<string>> dictionary = kvp.Value;

                foreach (var kvpColor in colorCount)
                {
                    foreach (var value in dictionary)
                    {
                        if (kvpColor.Key == value.Key)
                        {
                            for (int i = 0; i < value.Value.Count(); i++)
                            {
                                Console.WriteLine($"({value.Key}) {value.Value[i]} <-> {kvp.Key}");
                            }
                        }
                    }
                    
                }
            }
        }
    }
}
