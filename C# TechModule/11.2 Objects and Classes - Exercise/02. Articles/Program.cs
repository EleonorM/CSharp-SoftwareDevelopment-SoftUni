namespace _02._Articles
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ").ToList();
            var article = new Article();
            article.Title = input[0];
            article.Content = input[1];
            article.Author = input[2];
            var rows = int.Parse(Console.ReadLine());
            for (int i = 0; i < rows; i++)
            {
                input = Console.ReadLine().Split(": ").ToList();
                if (input[0] == "Edit")
                {
                    article.Edit(input[1]);
                }
                else if (input[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(input[1]);
                }
                else if (input[0] == "Rename")
                {
                    article.Rename(input[1]);
                }
            }

            Console.WriteLine(article.ToString(article));
        }
    }

    public class Article
    {
        public string Title;
        public string Content;
        public string Author;

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public string ToString(Article article)
        {
            return $"{article.Title} - {article.Content}: {article.Author}";
        }
    }
}
