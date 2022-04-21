using System;

namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads the path to a file and subtracts the file name and its extension.

            string[] path = Console.ReadLine().Split("\\");

            string[] fullName = path[path.Length-1].Split(".");

            string extention = fullName[fullName.Length-1];
            string fileName = fullName[0];


            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extention}");


        }
    }
}
