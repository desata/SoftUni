using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings strings = new StackOfStrings();
            strings.Push("Pesho");
            strings.Push("Pesho1");
            strings.Push("Pesho2");
            strings.Push("Pesho3"); 
            strings.Push("Pesho4");

            strings.IsEmpty();
            strings.AddRange(new List<string>() {"1", "2", "5" });

        }
    }
}
