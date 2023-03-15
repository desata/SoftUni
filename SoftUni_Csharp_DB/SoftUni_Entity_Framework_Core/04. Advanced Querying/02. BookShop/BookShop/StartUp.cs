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

            string input = Console.ReadLine();
            string result = GetBooksByAgeRestriction(db, input);
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
    }
}