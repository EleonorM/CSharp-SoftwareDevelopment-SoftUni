using System;
using System.IO;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            var startPath = "text.txt";
            var zipPath = Path.Combine(Console.ReadLine(), "result.zip");
            var extractPath = Path.Combine(Console.ReadLine(), "extract");

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
