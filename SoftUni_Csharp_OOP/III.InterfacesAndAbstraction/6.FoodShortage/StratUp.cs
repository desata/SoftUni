using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StratUp
    {
        static void Main(string[] args)
        {

            int numberOfPeople = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();
            IBuyer buyer;

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] line = Console.ReadLine().Split();
                string name = line[0];
                int age = int.Parse(line[1]);

                if (line.Length == 4)
                {
                    string id = line[2];
                    string birthdate = line[3];
                    buyer = new Citizen(name, age, id, birthdate);
                    buyersByName[name] = new Citizen(name, age, id, birthdate);
                }
                else
                {
                    string group = line[2];
                    buyer = new Rebel(name, age, group);
                    buyersByName[name] = new Rebel(name, age, group);
                }
                

            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                if (!buyersByName.ContainsKey(command))
                {
                    continue;
                }

                buyer = buyersByName[command];
                buyer.BuyFood();
            }

            int sum = buyersByName.Values.Sum(s => s.Food);
            Console.WriteLine(sum);



        }
    }
}
