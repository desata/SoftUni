using System;

namespace doggyYears
{
    class Program
{
        static void Main(string[] args)
        {

            string L = Console.ReadLine(); // a to h
            int R = int.Parse(Console.ReadLine()); //1 to 8

            switch (L)
            {
                case "a":
                case "c":
                case "e":
                case "g":
                    if (R % 2 != 0)
                    {
                        //Console.WriteLine(R % 2 != 0);
                        Console.WriteLine("dark");
                    }
                    else
                    {
                        Console.WriteLine("light");
                    }
                    break;

                case "b":
                case "d":
                case "f":
                case "h":
                    if (R % 2 == 0)
                    {
                       // Console.WriteLine(R % 2 == 0);
                        Console.WriteLine("dark");
                    }
                    else
                    {
                        Console.WriteLine("light");
                    }
                break;

                default:
                    Console.WriteLine("error");
                break;
            }
            
        }
}
}