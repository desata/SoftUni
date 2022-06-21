using System;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main()
        {
            var personInfo = Console.ReadLine().Split();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var address = $"{personInfo[2]}";
            var city = $"{personInfo[3]}";

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var beerLitters = int.Parse(nameAndBeer[1]);
            var Isdrunk = false;
            if (nameAndBeer[2] == "drunk")
            {
                Isdrunk = true;
            }
            else
            {
                Isdrunk = false;
            };

            var numerInput = Console.ReadLine().Split();
            var intNum = numerInput[0];
            var doubleNum = double.Parse(numerInput[1]);
            var bank = numerInput[2];


            Treeuple<string, string, string> firstTuple = new Treeuple<string, string, string>(fullName, address, city);

            Treeuple<string, int, bool> secondTuple = new Treeuple<string, int, bool>(name, beerLitters, Isdrunk);

            Treeuple<string, double, string> thirddTuple = new Treeuple<string, double, string>(intNum, doubleNum, bank);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirddTuple);
        }
    }
}
