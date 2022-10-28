using FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            IBuyer buyer = null;


            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split();
                string name = person[0];
                int age = int.Parse(person[1]);

                if (person.Length == 3)
                {
                    //Rebel
                    string group = person[2];

                    buyersByName[name] = new Rebel(name, age, group);


                }
                if (person.Length == 4)
                {
                    //Citizen
                    string id = person[2];
                    string birthdate = person[3];

                    buyersByName[name] = new Citizen(name, age, id, birthdate);

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
