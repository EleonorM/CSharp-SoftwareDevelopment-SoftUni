using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. Odd Lines
            //using (var reader = new StreamReader("Resources/01. Odd Lines/Input.txt"))
            //{
            //    var counter = 0;
            //    while (true)
            //    {
            //        var line = reader.ReadLine();

            //        if (line == null)
            //        {
            //            break;
            //        }

            //        if (counter % 2 != 0)
            //        {
            //            Console.WriteLine(line);
            //        }
            //
            //        counter++;
            //    }
            //}

            //02.Line Numbers
            //using (var reader2 = new StreamReader("Resources/02. Line Numbers/Input.txt"))
            //{
            //    var counter = 1;
            //    while (true)
            //    {
            //        var line = reader2.ReadLine();

            //        if (line == null)
            //        {
            //            break;
            //        }

            //        line = $"{counter}. {line}";
            //        counter++;

            //        using (var writer = new StreamWriter("Output.txt", true))
            //        {
            //            writer.WriteLine(line);
            //        }
            //    }
            //}


            // 03. Word Count
            var dictionary = new Dictionary<string, int>();
            var list = new List<string>();
            var text = new List<string>();

            using (var reader = new StreamReader("C:/Elie/SoftUni/Live/Fundamentals/C# Advanced/4.1 Streams, Files and Directories - Lab/Streams/Resources/03. Word Count/text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    list.Add(line);
                }

                using (var reader2 = new StreamReader("C:/Elie/SoftUni/Live/Fundamentals/C# Advanced/4.1 Streams, Files and Directories - Lab/Streams/Resources/03. Word Count/words.txt"))
                {
                    var line = reader2.ReadLine().Split();
                    for (int i = 0; i < line.Length; i++)
                    {
                        dictionary[line[i]] = 0;
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    text = list[i].Split(new string[] { "…", ",", ".", "-", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    for (int k = 0; k < text.Count; k++)
                    {
                        string word = text[k].ToLower();
                        if (dictionary.ContainsKey(word))
                        {
                            dictionary[word]++;
                        }
                    }
                }
            }


            var result = dictionary.OrderByDescending(m => m.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

            // 04. Merge Files

            //using (var reader = new StreamReader("C:/Elie/SoftUni/Live/Fundamentals/C# Advanced/4.1 Streams, Files and Directories - Lab/Streams/Resources/04. Merge Files/FileOne.txt"))
            //{
            //    using (var writer = new StreamWriter("Merged.txt", true))
            //    {
            //        while (true)
            //        {
            //            var line = reader.ReadLine();

            //            if (line == null)
            //            {
            //                break;
            //            }

            //            writer.WriteLine(line);
            //        }

            //        using (var reader2 = new StreamReader("C:/Elie/SoftUni/Live/Fundamentals/C# Advanced/4.1 Streams, Files and Directories - Lab/Streams/Resources/04. Merge Files/FileTwo.txt"))
            //        {
            //            while (true)
            //            {
            //                var line = reader2.ReadLine();

            //                if (line == null)
            //                {
            //                    break;
            //                }

            //                writer.WriteLine(line);
            //            }
            //        }
            //    }
            //}

            //05.Slice File 

            //int fileCount = int.Parse(Console.ReadLine());

            //using (var reader = new FileStream("Resources/05. Slice File/sliceMe.txt", FileMode.Open))
            //{
            //    var partLenght = Math.Ceiling((double)reader.Length / fileCount);
            //    for (int i = 0; i < fileCount; i++)
            //    {
            //        var currentFileName = $"slice-{i}.txt";
            //        var currentTotalBytes = 0;
            //        using (var writer = new FileStream($"Resources/05. Slice File/{currentFileName}", FileMode.Create))
            //        {
            //            while (true)
            //            {
            //                var buffer = new byte[(int)Math.Min(4096, partLenght)];
            //                var totalRead = reader.Read(buffer, 0, buffer.Length);
            //                if (totalRead == 0)
            //                {
            //                    break;
            //                }

            //                currentTotalBytes += totalRead;
            //                if (currentTotalBytes >= partLenght)
            //                {
            //                    break;
            //                }

            //                writer.Write(buffer, 0, totalRead);
            //            }
            //        }
            //    }
            //}

            //06. Folder Size

            //var dir = new DirectoryInfo("C:/Elie/SoftUni/Live/Fundamentals/C# Advanced/4.1 Streams, Files and Directories - Lab/Streams/Resources/06. Folder Size/TestFolder");

            //foreach (var file in dir.GetFiles())
            //{
            //    File.AppendAllText("Text.txt", $"{(double)file.Length / 1024 / 1024:f2} MB. ");
            //}
        }
    }
}
