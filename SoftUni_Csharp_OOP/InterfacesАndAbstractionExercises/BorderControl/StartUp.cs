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
            List<string> ids = new List<string>();


            while (true)
            {
                if (line[0] == "End")
                {
                    break;
                }
                else if (line.Length == 3)
                {
                    ids.Add(line[2]);
                }
                else
                {
                    ids.Add(line[1]);
                }
                line = Console.ReadLine().Split().ToArray();
            }
            string fakeId = Console.ReadLine();

            foreach (string id in ids)
            {
                if (id.EndsWith(fakeId))
                {
                    Console.WriteLine(id);
                }

            }

        }
    }
}
