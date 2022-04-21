using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string command = "";
            List<string> chatHistory = new List<string>();

            while (command != "end")
            {
                command = Console.ReadLine();
                string[] cmdArgs = command.Split(' ').ToArray();
                string cmd = cmdArgs[0];

                if (cmd == "Chat")
                {
                    string message = cmdArgs[1];
                    chatHistory.Add(message);
                }
                else if (cmd == "Delete")
                {
                    string message = cmdArgs[1];

                    if (chatHistory.Contains(message))
                    {
                        chatHistory.Remove(message);

                    }
                    else
                    {
                        continue;
                    }
                }
                else if (cmd == "Edit")
                {
                    string message = cmdArgs[1];
                    string editedVersion = cmdArgs[2];

                    if (chatHistory.Contains(message))
                    {
                        int index = chatHistory.IndexOf(message);
                        chatHistory[index] = editedVersion;

                    }
                    else
                    {
                        continue;
                    }

                }
                else if (cmd == "Pin")
                {
                    string message = cmdArgs[1];

                    if (chatHistory.Contains(message))
                    {

                        int index = chatHistory.IndexOf(message);


                        for (int i = 0; i < 1; i++)
                        {
                            string element = chatHistory[index];

                            for (int j = index; j < chatHistory.Count - 1; j++)
                            {
                                chatHistory[j] = chatHistory[j + 1];
                            }
                            chatHistory[chatHistory.Count - 1] = element;
                        }

                    }
                    else
                    {
                        continue;
                    }
                }
                else if (cmd == "Spam")
                {

                    for (int i = 1; i < cmdArgs.Length; i++)
                    {

                        string message = cmdArgs[i];
                        chatHistory.Add(message);

                    }
                }
                
            }
            Console.WriteLine(string.Join("\n", chatHistory));
        }
    }
}
