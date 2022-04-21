using System;

namespace Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            string truePassword = "s3cr3t!P@ssw0rd";
            string pass = Console.ReadLine();
            if (pass == truePassword)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }

        }
    }
}

/*
 Password Guess

Да се напише програма, която чете парола (един ред с произволен текст), 
въведена от потребителя и проверява, дали въведеното съвпада с фразата "s3cr3t!P@ssw0rd". 
При съвпадение да се изведе "Welcome". При несъвпадение да се изведе "Wrong password!". 
 */