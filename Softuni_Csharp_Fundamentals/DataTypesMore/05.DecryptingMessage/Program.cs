using System;

namespace _05.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will receive a key (integer) and n characters afterward. Add the key to each of the characters and append them to a message. At the end print the message, which you decrypted. 
            //            Input
            //•	On the first line, you will receive the key
            //•	On the second line, you will receive n – the number of lines, which will follow
            //•	On the next n lines – you will receive lower and uppercase characters from the Latin alphabet

            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            string message = "";

            for (int i = 0; i < lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int letterNum = (int)letter + key;
                message += (char)letterNum;
            }
            Console.Write(message);

        }
    }
}
