using System;
using System.Text;

namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads user names on a single line (joined by ", ") and prints all valid usernames.
            //A valid username:
            //•	Has length between 3 and 16 characters and
            //•	Contains only letters, numbers, hyphens, and underscores
            // if (second.Contains(first))
            //{
            //    second = second.Remove(index, first.Length);
            //}
            //foreach (char item in text)
            //{
            //    if (char.isdigit(item))
            //    {
            //        digit += item;
            //    }
            //    else if (char.isletter(item))
            //    {
            //        letter += item;
            //    }
            string[] usernames = Console.ReadLine().Split(", ");

            //StringBuilder result = new StringBuilder();


            foreach (var username in usernames)
            {

                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool isValidUsername = true;

                    foreach (char item in username)
                    {
                        if (!(char.IsLetterOrDigit(item) || (item == '-') || (item == '_')))
                        {
                            isValidUsername = false;
                            break;
                        }
                    }
                    if (isValidUsername)
                    {
                        Console.WriteLine(username);
                    }

                }
            }

            

        }
    }
}
