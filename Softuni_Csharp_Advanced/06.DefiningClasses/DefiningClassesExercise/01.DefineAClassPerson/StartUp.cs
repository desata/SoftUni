using System;

namespace DefiningClasses
{
    public class StartUp
    {


        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            
            Person person = new Person();
            person.Name = name;
            person.Age = age;

            Person person1 = new Person();
            person1.Name = "Alice";
            person1.Age = 2;

            Print(person.Name, person.Age);
            Print(person1.Name, person1.Age);
        }

        static void Print(object name, object age)
        {
            Console.WriteLine(name);
            Console.WriteLine(age);
        }

    }
}
