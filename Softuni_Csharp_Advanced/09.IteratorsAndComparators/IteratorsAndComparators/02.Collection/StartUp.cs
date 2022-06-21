using System;
using System.Linq;

namespace _02.Collection
{
    public class StartUp
    {
        static void Main()
        {
            string command = "";
            ListyIterator<string> listy = null;

            while ((command = Console.ReadLine()) != "END")
            {
                var argument = command.Split();

                if (argument[0] == "Create")
                {
                    listy = new ListyIterator<string>(argument.Skip(1).ToArray());
                    
                }
                else if (argument[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (argument[0] == "Print")
                {
                    listy.Print();
                }
                else if (argument[0] == "PrintAll")
                {
                    listy.PrintAll();
                }
                else if (argument[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
            }
        }
    }
}
