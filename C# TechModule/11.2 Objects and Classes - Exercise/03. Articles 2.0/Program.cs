namespace _03._Articles_2._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var articles = new List<Article>();

            var rows = int.Parse(Console.ReadLine());
            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(", ").ToList();
                var article = new Article();
                article.Title = input[0];
                article.Content = input[1];
                article.Author = input[2];
                articles.Add(article);
            }

            var orderBy = Console.ReadLine();
            if (orderBy == "title")
            {
                articles = articles.OrderBy(o => o.Title).ToList();
            }
            else if (orderBy == "author")
            {
                articles = articles.OrderBy(o => o.Author).ToList();
            }
            else if (orderBy == "content")
            {
                articles = articles.OrderBy(o => o.Content).ToList();
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString(article));
            }
        }
    }

    public class Article
    {
        public string Title;
        public string Content;
        public string Author;

        public string ToString(Article article)
        {
            return $"{article.Title} - {article.Content}: {article.Author}";
        }
    }
}
