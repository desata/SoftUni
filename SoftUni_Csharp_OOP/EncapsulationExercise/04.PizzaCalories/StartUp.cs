using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string name = pizzaInput[1];

            string[] doughInput = Console.ReadLine().Split();
            string flourType = doughInput[1];
            string backingTechnique = doughInput[2];
            int grams = int.Parse(doughInput[3]);

            try
            {

                Dough dough = new Dough(flourType, backingTechnique, grams);
                Pizza pizza = new Pizza(name, dough);

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] toppingInput = input.Split();
                    string toppingType = toppingInput[1];
                    int toppingGrams = int.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, toppingGrams);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");

            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }
        }
    }
}
