using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // On the first line, you will be given a sequence of strings, separated by a comma and a white space
            // On the next lines, you will be given commands until there are no songs in the queue

            string[] songList = Console.ReadLine().Split(", ");
            Queue<string> PlayList = new Queue<string>(songList);
            string input = Console.ReadLine();

            while (PlayList.Count > 0)
            {
                string command = input;
                if (command == "Play")
                {
                    PlayList.Dequeue();
                    if (PlayList.Count == 0)
                    {
                        Console.WriteLine("No more songs!");
                        break;
                    }
                }
                else if (command.Contains("Add"))
                {
                    string[] songName = input.Split("Add ").ToArray();

                    if (!PlayList.Contains(songName[1]))
                    {
                        PlayList.Enqueue(songName[1]);
                    }
                    else
                    {
                        Console.WriteLine($"{songName[1]} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine($"{string.Join(", ", PlayList)}");
                }

                input = Console.ReadLine();

            }
        }
    }
}