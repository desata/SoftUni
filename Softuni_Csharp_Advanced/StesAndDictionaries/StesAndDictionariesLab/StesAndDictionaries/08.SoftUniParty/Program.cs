using System;
using System.Collections.Generic;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //

            string input = Console.ReadLine();
                        HashSet<string> vipList = new HashSet<string>();
            HashSet<string> regList = new HashSet<string>();

            while (input != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vipList.Add(input);
                    }
                    else
                    {
                        regList.Add(input);
                    }
                    input = Console.ReadLine();
                }
            }

            input = Console.ReadLine();
            while (input != "END")
            {
                if (input.Length == 8)
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vipList.Remove(input);
                    }
                    else
                    {
                        regList.Remove(input);
                    }
                    input = Console.ReadLine();
                }
            }

            //print results
            Console.WriteLine(vipList.Count + regList.Count);

            if (vipList.Count > 0)
            {
                foreach (var guest in vipList)
                {
                    Console.WriteLine(guest);
                }
            }
            if (regList.Count > 0)
            {
                foreach (var guest in regList)
                {
                    Console.WriteLine(guest);
                }

            }
        }
    }
}
