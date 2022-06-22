using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will be given two lines of input.
            //The first line will be an array of strings, separated by a single space, representing meals that John can eat.
            //The second line will be an array of integers, separated by a single space, representing the maximum calories intake per day. 
            string[] mealsCanEat = Console.ReadLine().Split(); // stack
            int[] caloriesIntakePerDay = Console.ReadLine().Split().Select(int.Parse).ToArray(); //queue
            //salad	350 ; soup    490 ; pasta   680 ; steak   790
            Stack<int> calories = new Stack<int>(caloriesIntakePerDay);
            Queue<string> meals = new Queue<string>(mealsCanEat);

            //salad soup salad steak
            //2500 1800 1500

            while (meals.Count != 0 || calories.Count != 0)
            {
                string currentMeal = meals.Peek();
                int currentCalories = calories.Peek();
                int food = 0;

                if (currentMeal == "salad")
                {
                    food = 350;

                }
                else if (currentMeal == "soup")
                {
                    food = 490;
                }
                else if (currentMeal == "pasta")
                {
                    food = 680;
                }
                else if (currentMeal == "steak")
                {
                    food = 790;
                }

                if (currentCalories - food > 0)
                {
                    meals.Dequeue();
                    currentCalories = currentCalories - food;
                    calories.Pop();
                    calories.Push(currentCalories);
                }
                else if (currentCalories == food)
                {
                    meals.Dequeue();
                    calories.Pop();
                }
                else
                {
                    if (calories.Count > 1)
                    {
                        currentCalories = food - currentCalories;
                        calories.Pop();
                        calories.Push(calories.Pop() - currentCalories);
                        meals.Dequeue();
                    }
                    else
                    {
                        meals.Dequeue();
                        calories.Pop();
                        break;
                    }


                }

                if (meals.Count == 0 || calories.Count == 0)
                {
                    break;
                }

            }
            if (meals.Count > 0)
            {
                //Console.WriteLine(String.Join(" ", meals));
                Console.WriteLine($"John ate enough, he had {mealsCanEat.Length - meals.Count} meals.");
                Console.WriteLine($"Meals left: {String.Join(", ", meals)}.");
                
            }
            if (calories.Count > 0)
            {
                //Console.WriteLine(String.Join(" ", calories));
                Console.WriteLine($"John had {mealsCanEat.Length - meals.Count} meals.");
                Console.WriteLine($"For the next few days, he can eat {String.Join(", ", calories)} calories.");
            }

           
        }
    }
}
