namespace _2._Line_Numbers
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            var counter = 1;
            using (var reader = new StreamReader("text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    var lineChar = line.ToCharArray();
                    var punctuationCounter = 0;
                    var letterCounter = 0;

                    for (int i = 0; i < lineChar.Length; i++)
                    {
                        if (char.IsLetter(lineChar[i]))
                        {
                            letterCounter++;
                        }
                        else if (char.IsPunctuation(lineChar[i]))
                        {
                            punctuationCounter++;
                        }
                    }

                    using (var writer = new StreamWriter("Output.txt", true))
                    {
                        writer.WriteLine($"Line:{counter} {line} ({letterCounter})({punctuationCounter})");
                    }

                    counter++;
                }
            }
        }
    }
}
