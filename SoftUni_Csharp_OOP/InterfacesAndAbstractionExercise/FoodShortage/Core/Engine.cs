using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage
{
    public class Engine
    {
        private List<IBuyer> repository;

        public Engine()
        {
            this.repository = new List<IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            FillRepository(n);

            string names = Console.ReadLine();
            while (names != "End")
            {
                IBuyer newBuyer = BuyFood(names, repository);
                newBuyer?.BuyFood();
                names = Console.ReadLine();
            }
            PrintFinalResult();
        }

        private void PrintFinalResult()
        {
            int totalFoodBought = repository.Sum(b => b.Food);
            Console.WriteLine(totalFoodBought);
        }

        private IBuyer BuyFood(string names, List<IBuyer> repository)
        {
            IBuyer currbuyer = repository.FirstOrDefault(b => b.Name == names);
            return currbuyer;
        }

        private void FillRepository(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                IBuyer ibuyer = null;

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string date = input[3];

                    ibuyer = new Citizen(name, age, id, date);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    ibuyer = new Rebel(name, age, group);
                }
                if (ibuyer != null)
                {

                    this.repository.Add(ibuyer);
                }


            }

           
        }
    }
}
