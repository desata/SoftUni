using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StratUp
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split();
            List<IBirthable> birth = new List<IBirthable>();
            IBirthable birthable;

            while (line[0] != "End")
            {
                if (line[0] == "Citizen")
                {
                    string name = line[1];
                    int age = int.Parse(line[2]);
                    string id = line[3];
                    string birthdate = line[4];
                    birthable = new Citizen(name, age, id, birthdate);
                }
                else if (line[0] == "Pet")
                {
                    string name = line[1];
                    string birthdate = line[2];
                    birthable = new Pet(name, birthdate);
                }
                else
                {
                    line = Console.ReadLine().Split();
                    continue;
                    //string name = line[1];
                    //string id = line[2];
                    //Robot robot = new Robot(name, id);
                }
                birth.Add(birthable);

                line = Console.ReadLine().Split();
            }

            string SpecificYear = Console.ReadLine();

            List<string> bornInSpecificYear = birth.Where(y => y.Birthdate.EndsWith(SpecificYear)).Select(i => i.Birthdate).ToList();

            foreach (var born in bornInSpecificYear)
            {
                Console.WriteLine(born);
            }
        }
    }
}
