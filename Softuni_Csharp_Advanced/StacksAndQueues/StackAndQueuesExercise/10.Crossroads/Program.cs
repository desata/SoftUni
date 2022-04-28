using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int passedCars = 0;
            Queue<string> cars = new Queue<string>();

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                    command = Console.ReadLine();
                    continue;
                }

                int currentGreenLigth = greenLightDuration;
                while (currentGreenLigth > 0 && cars.Count > 0)
                {
                    string currentCar = cars.Dequeue();

                    if (currentGreenLigth - currentCar.Length >= 0)
                    {
                        currentGreenLigth -= currentCar.Length;
                        passedCars++;
                        continue;
                    }
                    if (currentGreenLigth + freeWindowDuration - currentCar.Length >= 0)
                    {
                        currentGreenLigth = 0;
                        passedCars++;
                        continue;
                    }
                    int characterHit = currentGreenLigth + freeWindowDuration;

                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{currentCar} was hit at {currentCar[characterHit]}.");

                    Environment.Exit(0);
                }


                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");

            //Output
            //If a crash happens, end the program and print:
            //"A crash happened!"
            //"{car} was hit at {characterHit}."
            //If everything goes smoothly and you receive an "END" command, print:
            //"Everyone is safe."
            //"{totalCarsPassed} total cars passed the crossroads."

        }
    }
}
