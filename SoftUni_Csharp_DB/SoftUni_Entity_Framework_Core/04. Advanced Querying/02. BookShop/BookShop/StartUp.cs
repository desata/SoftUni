namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
           // DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(db, input);

            string result = GetGoldenBooks(db);
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

    }
}