using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int wastedFood = 0;

            while (plates.Count != 0 && guests.Count != 0)
            {

                int currentGuest = guests.Peek();
                int currentPlate = plates.Peek();

                if (currentGuest - currentPlate > 0)
                {
                    plates.Pop();
                    currentGuest -= currentPlate;
                    while (currentGuest > 0)
                    {
                        int newplate = plates.Peek();
                        if (currentGuest - newplate > 0)
                        {
                            
                            plates.Pop();
                        }
                        else
                        {
                            guests.Dequeue();
                            plates.Pop();
                            if (newplate - currentGuest > 0)
                            {
                                wastedFood += (newplate - currentGuest);
                            }
                        }
                        currentGuest -= newplate;

                    }

                }
                else if (currentGuest - currentPlate < 0)
                {
                    plates.Pop();
                    guests.Dequeue();
                    wastedFood += (currentPlate - currentGuest);

                }
                else
                {
                    plates.Pop();
                    guests.Dequeue();

                }

                if (plates.Count == 0 || guests.Count == 0)
                {
                    break;
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");

        }
    }
}
