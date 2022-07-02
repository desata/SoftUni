using System;

namespace Person
{
    public class StartUp
    {
        public static void Main()
        {
            

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age <= 15)
            {
                Child person = new Child(name, age);
                Console.WriteLine(person);
            }
            else 
            {
                Person person = new Person(name, age);
                Console.WriteLine(person);
            }
        }
    }
}