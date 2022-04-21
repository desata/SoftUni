using System;
using System.Collections.Generic;

namespace _01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // On the first line of the input, you will receive the encrypted message.
            // After that, until the "Decode" command is given,
            // you will be receiving strings with instructions for different operations
            // that need to be performed upon the concealed message to interpret it and reveal its true content.
            // There are several types of instructions, split by '|'



            string message = Console.ReadLine();
            List<char> encrypted = new List<char>();
            encrypted.AddRange(message);
            string command = Console.ReadLine();
           

            while (command != "Decode")
            {
                
                string[] argument = command.Split('|');

                if (argument[0] == "Move")
                {
                   int rotation = int.Parse(argument[1]);
                    for (int i = 0; i < rotation; i++)
                    {
                        
                        char temp = encrypted[0];

                        for (int j = 0; j < encrypted.Count - 1; j++)
                        {
                            encrypted[j] = encrypted[j + 1];
                        }
                        encrypted[encrypted.Count - 1] = temp;
                    }
                    
                }
                else if (argument[0] == "Insert")
                {


                    encrypted.InsertRange(int.Parse(argument[1]), argument[2]);
                   // result = $"The decrypted message is: {string.Join("", encrypted)}";

                }
                else if (argument[0] == "ChangeAll")
                {
                    char oldLetter = char.Parse(argument[1]);
                    char newLetter = char.Parse(argument[2]);

                    for (int i = 0; i < encrypted.Count-1; i++)
                    {
                        if (encrypted[i] == oldLetter)
                        {
                            encrypted[i] = newLetter;
                        }
                    }
                    //Console.WriteLine(encrypted[3]);



                   //result = $"The decrypted message is: {string.Join("", encrypted)}";
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {string.Join("", encrypted)}");

        }
    }
}
