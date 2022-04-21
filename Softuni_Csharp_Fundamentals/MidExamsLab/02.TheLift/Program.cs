using System;
using System.Linq;

namespace _02.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	On the first line, you will receive how many people are waiting to get on the lift
            //•	On the second line, you will receive the current state of the lift separated by a single space: " ".

            int peopleWaiting = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string result = "";

            if (peopleWaiting > lift.Length * 4)
            {
                for (int i = 0; i < lift.Length; i++)
                {
                    int inwagon = lift[i];
                    lift[i] = 4;
                    peopleWaiting = (peopleWaiting + inwagon) - 4;

                }
                int people = peopleWaiting - lift.Length * 4;
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
            }
            else
            {
                for (int i = 0; i < lift.Length; i++)
                {

                    while (peopleWaiting > 0 || peopleWaiting >= lift.Length * 4)
                    {

                        if (lift[i] == 4)
                        {
                            continue;
                        }
                        else
                        {
                            if (peopleWaiting >= 4)
                            {

                                int inwagon = lift[i];
                                lift[i] = 4;
                                peopleWaiting = (peopleWaiting + inwagon) - 4;
                                i++;
                            }
                            else
                            {

                                lift[i] = peopleWaiting;
                                Console.WriteLine("The lift has empty spots!");
                                break;

                            }

                        }
                    }

                }
            }
            
            Console.WriteLine(String.Join(" ", lift));
        }
    }
}
