namespace _05._HTML
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var title = Console.ReadLine();
            var content = Console.ReadLine();
            var comments = new List<string>();

            while (true)
            {
                var comment = Console.ReadLine();
                if (comment == "end of comments")
                {
                    break;
                }
                comments.Add(comment);
            }

            PrintHTMLTag("title", title);
            PrintHTMLTag("content", content);
            foreach (var item in comments)
            {
                PrintHTMLTag("comment", item);
            }

        }

        public static void PrintHTMLTag(string type, string toPrint)
        {
            if (type == "title")
            {
                Console.WriteLine("<h1>");
                PrintHTMLContent(toPrint);
                Console.WriteLine("</h1>");
            }
            else if (type == "content")
            {
                Console.WriteLine("<article>");
                PrintHTMLContent(toPrint);
                Console.WriteLine("</article>");
            }
            else if (type == "comment")
            {
                Console.WriteLine("<div>");
                PrintHTMLContent(toPrint);
                Console.WriteLine("</div>");
            }
        }
        public static void PrintHTMLContent(string toPrint)
        {
            Console.WriteLine($"    {toPrint}");
        }
    }
}
