using System;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string password = Console.ReadLine();


            bool isTrue = checkLength(password) && checkNumOrDigits(password) && checkAtLeastTwoDigits(password);


            if (isTrue)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!checkLength(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!checkNumOrDigits(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!checkAtLeastTwoDigits(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }

            }


        }

        //checkLength
        static bool checkLength(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;

            }

            return false;
        }

        //checkNumOrDigits
        static bool checkNumOrDigits(string password)
        {
            foreach (char ch in password)
            {

                if (Char.IsLetterOrDigit(ch) != true)
                {
                    return false;
                }
            }

            return true;
        }

        //checkAtLeastTwoDigits
        static bool checkAtLeastTwoDigits(string password)
        {
            int count = 0;
            foreach (char ch in password)
            {

                if (Char.IsNumber(ch))
                {

                    count++;

                }
            }
            if (count < 2)
            {

                return false;

            }

            return true;
        }

    }
}