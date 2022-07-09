using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations
{
    public class Engine
    {
        private List<IBirthable> repository;

        public Engine()
        {
            this.repository = new List<IBirthable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] arguments = input.Split().ToArray();
                CreateIBirthable(arguments);
                input = Console.ReadLine();
            }

            string year = Console.ReadLine();
            string[] dateOfBirth = this.repository.Where(i => i.Date.EndsWith(year)).Select(i => i.Date).ToArray();

            PrintFinalResult(dateOfBirth);
        }

        private void PrintFinalResult(string[] dateOfBirth)
        {
            foreach (var date in dateOfBirth)
            {
                Console.WriteLine(date);
            }
        }

        private void CreateIBirthable(string[] arguments)
        {
            IBirthable ibirthable;

            if (arguments.Length == 5)
            {
                string name = arguments[1];
                int age = int.Parse(arguments[2]);
                string id = arguments[3];
                string date = arguments[4];

                ibirthable = new Citizens(name, age, id, date);
            }
            else if (arguments[0] == "Pet")
            {
                string name = arguments[1];
                string date = arguments[2];

                ibirthable = new Pets(name, date);
            }
            else
            {
                return;
            }



            this.repository.Add(ibirthable);

        }
    }
}
