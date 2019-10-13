namespace _5._Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var path = Console.ReadLine();
            var files = Directory.GetFiles(path);
            var filesInfo = new Dictionary<string, List<FileProperties>>();
            for (int i = 0; i < files.Length; i++)
            {
                var fileInfo = new FileInfo(files[i]);
                var extention = fileInfo.Extension;
                if (!filesInfo.ContainsKey(extention))
                {
                    filesInfo[extention] = new List<FileProperties>();
                }

                var newFile = new FileProperties() { Name = fileInfo.Name, Size = fileInfo.Length * 0.001 };
                filesInfo[extention].Add(newFile);
            }

            filesInfo = filesInfo.OrderByDescending(x => x.Value.Count).ToDictionary(k => k.Key, v => v.Value);
            File.Create("report.txt").Close();

            foreach (var kvp in filesInfo)
            {
                File.AppendAllText("report.txt", $"\n{kvp.Key}");
                var values = kvp.Value.OrderBy(x => x.Size).ToList();
                foreach (var value in values)
                {
                    File.AppendAllText("report.txt", $"\n--{value.Name} - {value.Size}kb");
                }
            }
        }
        public class FileProperties
        {
            public string Name { get; set; }

            public double Size { get; set; }
        }
    }
}
