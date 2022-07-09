using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Engine
    {
        private List<IIdentifieble> repository;

        public Engine()
        {
            this.repository = new List<IIdentifieble>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] arguments = input.Split().ToArray();
                CreateIIdentifiable(arguments);
                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();
            string[] fake = this.repository.Where(i => i.Id.EndsWith(fakeId)).Select(i => i.Id).ToArray();

            PrintFinalResult(fake);
        }

        private void PrintFinalResult(string[] fake)
        {
            foreach (var ids in fake)
            {
                Console.WriteLine(ids);
            }
        }

        private void CreateIIdentifiable(string[] arguments)
        {
            IIdentifieble identifieble;

            if (arguments.Length == 3)
            {
                string name = arguments[0];
                int age = int.Parse(arguments[1]);
                string id = arguments[2];

                identifieble = new Citizens(name, age, id);

            }
            else
            {
                string model = arguments[0];

                string id = arguments[1];
                identifieble = new Robots(model, id);
            }

            this.repository.Add(identifieble);
        }
    }
}
