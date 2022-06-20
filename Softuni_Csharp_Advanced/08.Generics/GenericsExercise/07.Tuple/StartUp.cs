using System;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main()
        {
            var personInfo = Console.ReadLine().Split();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var city = $"{personInfo[2]}";

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var beerLitters = int.Parse(nameAndBeer[1]);

            var numerInput = Console.ReadLine().Split();
            var intNum = int.Parse(numerInput[0]);
            var doubleNum = double.Parse(numerInput[1]);


            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, city);

            Tuple<string, int> secondTuple = new Tuple<string, int>(name, beerLitters);

            Tuple<int, double> thirddTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirddTuple);
        }
    }
}
