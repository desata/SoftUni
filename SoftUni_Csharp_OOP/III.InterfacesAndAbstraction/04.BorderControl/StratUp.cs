using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StratUp
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split();
            List<IIdentifiable> ids = new List<IIdentifiable>();
            IIdentifiable identifiable;

            while (line[0] != "End")
            {
                if (line.Length == 3)
                {
                    string name = line[0];
                    int age = int.Parse(line[1]);
                    string id = line[2];
                    identifiable = new Citizen(name, age, id);
                }
                else
                {
                    string model = line[0];
                    string id = line[1];
                    identifiable = new Robot(model, id);
                }
                ids.Add(identifiable);

                line = Console.ReadLine().Split();
            }

            string lastDigit = Console.ReadLine();

            List<string> fakeIds = ids.Where(i => i.Id.EndsWith(lastDigit)).Select(i => i.Id).ToList();

            foreach (var item in fakeIds)
            {
                Console.WriteLine(item);
            }
        }
    }
}
