namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using Models.Enums;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                ////01. Age Restriction
                //var restriction = Console.ReadLine();
                //Console.WriteLine(GetBooksByAgeRestriction(db, restriction));

                ////02. Golden Books
                //Console.WriteLine(GetGoldenBooks(db));

                ////03. Books by Price
                //Console.WriteLine(GetBooksByPrice(db));

                ////04.Not Released In
                //var year = int.Parse(Console.ReadLine());
                //Console.WriteLine(GetBooksNotReleasedIn(db,year));

                ////05.Book Titles by Category
                //var input = Console.ReadLine();
                //Console.WriteLine(GetBooksByCategory(db, input));

                ////06.Released Before Date
                //var date = Console.ReadLine();
                //Console.WriteLine(GetBooksReleasedBefore(db, date));

                ////07.Author Search
                //var input = Console.ReadLine();
                //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

                ////08. Book Search
                //var input = Console.ReadLine();
                //Console.WriteLine(GetBookTitlesContaining(db, input));

                ////09. Book Search by Author
                //var input = Console.ReadLine();
                //Console.WriteLine(GetBooksByAuthor(db, input));

                ////10. Count Books
                //var lengthCheck = int.Parse(Console.ReadLine());
                //Console.WriteLine(CountBooks(db, lengthCheck));

                ////11. Total Book Copies
                //Console.WriteLine(CountCopiesByAuthor(db));

                ////12. Profit by Category
                //Console.WriteLine(GetTotalProfitByCategory(db));

                ////13. Most Recent Books
                //Console.WriteLine(GetMostRecentBooks(db));

                ////14. Increase Prices
                //IncreasePrices(db);

                //15. Remove Books
                Console.WriteLine(RemoveBooks(db));
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200);
            int count = books.Count();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return count;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(x => x.Price += 5);

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.Select(b => new
                    {
                        b.Book.ReleaseDate,
                        b.Book.Title
                    })
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profit = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Sum1 = (decimal)c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(b => b.Sum1)
                .ThenBy(b => b.Name)
                .Select(b => $"{b.Name} ${b.Sum1}")
                .ToList();

            var result = string.Join(Environment.NewLine, profit);
            return result;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorCopies = context
                .Books
                .Select(b => new
                {
                    Author = new
                    {
                        b.AuthorId,
                        b.Author.FirstName,
                        b.Author.LastName
                    },
                    b.Copies
                })
                .GroupBy(b => new { b.Author.AuthorId, b.Author.FirstName, b.Author.LastName })
                .OrderByDescending(b => b.Sum(a => a.Copies))
                .Select(b => $"{b.Key.FirstName} {b.Key.LastName} - {b.Sum(a => a.Copies)}")
                .ToList();

            var result = string.Join(Environment.NewLine, authorCopies);
            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context
                .Books
                .Select(b => b.Title)
                .Where(b => b.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .Where(b => b.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.FirstName} {b.LastName})")
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Select(b => b.Title)
                .Where(b => b.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b)
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var books = context
                .Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateParsed = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context
                .Books
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .Where(b => b.ReleaseDate.Value.Date < dateParsed)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToList();
            var books = context
                .Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();


            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.ReleaseDate
                })
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Select(b => new { b.Title, b.Price })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context
                .Books
                .Select(b => new
                {
                    b.Title,
                    b.BookId,
                    b.Copies,
                    b.EditionType
                })
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, goldenBooks);
            return result;
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context
                .Books
                .Where(a => a.AgeRestriction == ageRestriction)
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }
    }
}
