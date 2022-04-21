using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.Zad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //03. Followers

            string[] input = Console.ReadLine().Split(": ");
            Dictionary<string, int> janesFollowers = new Dictionary<string,int>();

            while (input[0] != "Log out")
            {

                if (input[0] == "New follower")
                {
                    string username = input[1];
                    if (!janesFollowers.ContainsKey(username))
                    {
                        janesFollowers.Add(username,0);
                    }  
                }
                if (input[0] == "Like")
                {
                    string username = input[1];
                    int like = int.Parse(input[2]);
                    if (!janesFollowers.ContainsKey(username))
                    {
                        janesFollowers.Add(username, like);

                    }
                    else
                    {
                        janesFollowers[username] += like;
                    }
                }
                if (input[0] == "Comment")
                {
                    string username = input[1];

                    if (!janesFollowers.ContainsKey(username))
                    {
                        janesFollowers.Add(username, 1);

                    }
                    else
                    {
                        janesFollowers[username] += 1;
                    }
                }
                if (input[0] == "Blocked")
                {
                    string username = input[1];

                    if (janesFollowers.ContainsKey(username))
                    {
                        janesFollowers.Remove(username);

                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
                
               
                input = Console.ReadLine().Split(": ");
            }

            Console.WriteLine($"{janesFollowers.Count} followers");
            foreach (var follower in janesFollowers)
            {

                Console.WriteLine($"{follower.Key}: {follower.Value}");
                
            }
        }
    }
}
