namespace _1._EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                var counter = 1;
                while (true)
                {
                    var lineInput = reader.ReadLine();

                    if (lineInput == null)
                    {
                        break;
                    }

                    var line = lineInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (counter % 2 != 0)
                    {
                        var result = new List<string>();
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i].Contains('.'))
                            {
                                line[i] = line[i].Replace('.', '@');
                            }

                            if (line[i].Contains(','))
                            {
                                line[i] = line[i].Replace(',', '@');
                            }

                            if (line[i].Contains('-'))
                            {
                                line[i] = line[i].Replace('-', '@');
                            }

                            if (line[i].Contains('!'))
                            {
                                line[i] = line[i].Replace('!', '@');
                            }

                            if (line[i].Contains('?'))
                            {
                                line[i] = line[i].Replace('?', '@');
                            }
                        }

                        for (int i = line.Length - 1; i >= 0; i--)
                        {
                            result.Add(line[i]);
                        }

                        Console.WriteLine(string.Join(" ", result));
                    }

                    counter++;
                }
            }
        }
    }
}
