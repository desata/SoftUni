using System;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main()
        {
            //Create a generic class Box that can be initialized with any type and store the value. Override the ToString() method and print the type and stored value.

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<string>(input);
                Console.WriteLine(box);

            }

        }
    }
}
