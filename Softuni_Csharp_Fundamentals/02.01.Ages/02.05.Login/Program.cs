using System;

namespace _02._05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            /*On the first line, you will be given a username, your task is to try to log in the user. The user’s password is username reversed. On the next lines, you will receive passwords:
            •	If the password is incorrect print "Incorrect password. Try again."
            •	If the password is correct print: "User {username} logged in." and stop the program
            Keep in mind, on the fourth attempt if the password is still not correct print: "User {username} blocked!"
            Then the program stops.
            */

            string username = Console.ReadLine();
            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            int count = 0;
            string inputedPass = Console.ReadLine();

            while (inputedPass != password)
            {
                count++;
                if (count > 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                inputedPass = Console.ReadLine();
            }
            if (inputedPass == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
