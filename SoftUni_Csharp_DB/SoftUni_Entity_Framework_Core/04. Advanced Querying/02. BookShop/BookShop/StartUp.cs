namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            //02
            //string input = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(db, input);

            //03
            //string result = GetGoldenBooks(db);

            //04
            //string result = GetBooksByPrice(db);

            //05
            //int year = int.Parse(Console.ReadLine());
            //string result = GetBooksNotReleasedIn(db, year);

            //06
            //string input = Console.ReadLine();
            //string result = GetBooksByCategory(db, input);


            //07 
            //string input = Console.ReadLine();
            //string result = GetBooksReleasedBefore(db, input);

            //08
            //string input = Console.ReadLine();
            //string result = GetAuthorNamesEndingIn(db, input);

            //09
            //string input = Console.ReadLine();
            //string result = GetBookTitlesContaining(db, input);

            //10
            //string input = Console.ReadLine();
            //string result = GetBooksByAuthor(db, input);

            //11
            //int input = int.Parse(Console.ReadLine());
            //int result = CountBooks(db, input);

            //12
            //string result = CountCopiesByAuthor(db);

            //13
            //string result = GetTotalProfitByCategory(db);

            //14
            string result = GetMostRecentBooks(db);



            Console.WriteLine(result);
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            //Return in a single string all book titles, each on a new line, that have an age restriction, equal to the given command.
            //Order the titles alphabetically.
            //Read input from the console in your main method and call your method with the necessary arguments.
            //Print the returned string to the console.
            //Ignore the casing of the input.

            bool hasParsed = Enum.TryParse(typeof(AgeRestriction), command, true, out object? ageRestrictionValue);
            AgeRestriction ageRestriction;
            if (hasParsed)
            {
                ageRestriction = (AgeRestriction)ageRestrictionValue;

                var booksToPrint = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title).ToArray();


                return String.Join(Environment.NewLine, booksToPrint);
            }
            return null;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            //Return in a single string the titles of the golden edition books that have less than 5000 copies, each on a new line.
            //Order them by BookId ascending.
            //Call the GetGoldenBooks(BookShopContext context) method in your Main() and print the returned string to the console.

            var goldenBook = context.Books
                .OrderBy(b => b.BookId)
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => b.Title)
                .ToList();
                

            return String.Join(Environment.NewLine, goldenBook);


        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            //Return in a single string all titles and prices of books with a price higher than 40, each on a new row in the format given below.
            //Order them by price descending.

            StringBuilder sb = new StringBuilder();

            var booksByPrice = context.Books
                .OrderByDescending(b => b.Price)
                .Where(b => b.Price > 40)
                .Select (b => new
                { 
                Title = b.Title,
                Price = b.Price
                }).ToList();

            foreach (var b in booksByPrice)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
          
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            //Return in a single string with all titles of books that are NOT released in a given year.
            //Order them by bookId ascending.

            var bookNotReleased = context.Books
                .OrderBy(b => b.BookId)
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => b.Title).ToList();

            return String.Join(Environment.NewLine, bookNotReleased);


        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            //Return in a single string the titles of books by a given list of categories.
            //The list of categories will be given in a single line separated by one or more spaces.
            //Ignore casing.
            //Order by title alphabetically.

            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower()).ToArray();

            var booksByCategory = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, booksByCategory);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            //Return the title, edition type and price of all books that are released before a given date.
            //The date will be a string in the format "dd-MM-yyyy".
            //Return all of the rows in a single string, ordered by release date(descending).

            DateTime d = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);


            StringBuilder sb = new StringBuilder();


            var bookReleasedBefore = context.Books
                .OrderByDescending(b => b.ReleaseDate).ToList()
                .Where(b => b.ReleaseDate.Value < d)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType.ToString(),
                    Price = b.Price
                }).ToList();

            foreach (var b in bookReleasedBefore)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            //Return the full names of authors, whose first name ends with a given string.
            //Return all names in a single string, each on a new row, ordered alphabetically.

            StringBuilder sb = new StringBuilder();

            var autorByString = context.Authors
                .OrderBy(a => a.FirstName)
                .ThenBy(a =>a.LastName)
                .Where(a => a.FirstName.EndsWith(input.Trim()))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                }).ToList();

            foreach (var autor in autorByString)
            {
                sb.AppendLine($"{autor.FirstName} {autor.LastName}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            //Return the titles of the book, which contain a given string.
            //Ignore casing.
            //Return all titles in a single string, each on a new row, ordered alphabetically.

            var bookContainsString = context.Books
                .OrderBy(b => b.Title)
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title).ToList();

            return String.Join(Environment.NewLine, bookContainsString); 

        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            //Return all titles of books and their authors' names for books, which are written by authors whose last names start with the given string.
            //Return a single string with each title on a new row.
            //Ignore casing.
            //Order by BookId ascending.

            StringBuilder sb = new StringBuilder();

            var bookByAuthor = context.Books
                .OrderBy(a => a.BookId)
                .ThenBy(a => a.Author.LastName)
                .Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(a => new
                {
                    Title = a.Title,
                    AuthorFirstName = a.Author.FirstName,
                    AuthorLastName = a.Author.LastName
                }).ToList();

            foreach (var ba in bookByAuthor)
            {
                sb.AppendLine($"{ba.Title} ({ba.AuthorFirstName} {ba.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();

        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            //Return the number of books, which have a title longer than the number given as an input.

            var countBooks = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return countBooks;

        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            //Return the total number of book copies for each author.
            //Order the results descending by total book copies.
            //Return all results in a single string, each on a new line.

            StringBuilder stringBuilder = new StringBuilder();

            var copiesCountByAuthor = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                    .ToArray()
                    .OrderByDescending(b => b.TotalCopies);

            foreach (var c in copiesCountByAuthor)
            {
                stringBuilder.AppendLine($"{c.FullName} - {c.TotalCopies}");
            }
  

            return stringBuilder.ToString().TrimEnd();


        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            //Return the total profit of all books by category.
            //Profit for a book can be calculated by multiplying its number of copies by the price per single book.
            //Order the results by descending by total profit for a category and ascending by category name.
            //Print the total profit formatted to the second digit.

            StringBuilder sb = new StringBuilder();

            var totalProfit = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Profit = c.CategoryBooks
                    .Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .ToList()
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.CategoryName);

            foreach (var p in totalProfit)
            {
                sb.AppendLine($"{p.CategoryName} ${p.Profit:f2}");
            }


            return sb.ToString().TrimEnd();
        }



        public static string GetMostRecentBooks(BookShopContext context)
        {
            //Get the most recent books by categories.
            //The categories should be ordered by name alphabetically.
            //Only take the top 3 most recent books from each category – ordered by release date (descending).
            //Select and print the category name and for each book – its title and release year.

            StringBuilder sb = new StringBuilder();

            var mostRecentBooks = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    Category = c.Name,
                    MostRecentBooks = c.CategoryBooks
                   .OrderByDescending(cb => cb.Book.ReleaseDate)
                   .Take(3)
                   .Select(cb => new
                   {
                       BookTitle = cb.Book.Title,
                       ReleaseDate = cb.Book.ReleaseDate.Value.Year
                   })
                .ToList(),
                }).ToList();
                

            foreach (var c in mostRecentBooks)
            {

                sb.AppendLine($"--{c.Category}");

                foreach (var m in c.MostRecentBooks)
                {
                    sb.AppendLine($"{m.BookTitle} ({m.ReleaseDate})");
                }
               
            }

            return sb.ToString().TrimEnd();
        }



    }
}