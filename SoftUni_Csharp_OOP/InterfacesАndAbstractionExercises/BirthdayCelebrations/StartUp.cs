using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] line = Console.ReadLine().Split().ToArray();
            List<string> years = new List<string>();


            while (true)
            {
                if (line[0] == "End")
                {
                    break;
                }
                else if (line[0] == "Citizen")
                {
                    years.Add(line[4]);
                }
                else if (line[0] == "Pet")
                {
                    years.Add(line[2]);
                }
                line = Console.ReadLine().Split().ToArray();
            }
            string endsWith = Console.ReadLine();

            foreach (string id in years)
            {
                if (id.EndsWith(endsWith))
                {
                    Console.WriteLine(id);
                }

            }

        }
    }
}
