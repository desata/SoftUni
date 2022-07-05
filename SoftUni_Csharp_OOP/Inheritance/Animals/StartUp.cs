using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string input = Console.ReadLine();

            while (input != "Beast!")
            {

                string[] animalInfo = Console.ReadLine().Split();
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                Animal animal = default;

                if (input == "Cat")
                {
                    animal = new Cat(name, age, animalInfo[2]);

                }
                else if (input == "Dog")
                {
                    animal = new Dog(name, age, animalInfo[2]);

                }
                else if (input == "Frog")
                {
                    animal = new Frog(name, age, animalInfo[2]);

                }
                else if (input == "Kitten")
                {
                    animal = new Kitten(name, age);

                }
                else if (input == "Tomcat")
                {
                    animal = new Tomcat(name, age);

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Console.WriteLine(input);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                string sound = animal.ProduceSound();
                Console.WriteLine(sound);

                input = Console.ReadLine();
            }
        }
    }
}
