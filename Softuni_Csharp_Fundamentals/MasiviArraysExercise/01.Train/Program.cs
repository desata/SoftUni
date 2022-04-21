using System;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //A train has an **n** number of wagons (integer, received as input). 
            //On the next n lines, you will receive the number of people that are going to get on each wagon. 
            //Print out the number of passengers in each wagon followed by the total number of passengers on the train.

            int wagonsNumber = int.Parse(Console.ReadLine());
            int[] peoples = new int[wagonsNumber];
            int sum = 0;

            for (int i = 0; i < wagonsNumber; i++)
            {
                peoples[i] = int.Parse(Console.ReadLine());
                sum += peoples[i];
            }
            Console.WriteLine(String.Join(" ", peoples));
            Console.WriteLine(sum);

        }
    }
}
