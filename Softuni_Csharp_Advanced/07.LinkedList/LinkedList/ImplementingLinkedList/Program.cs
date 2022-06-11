using System;
using System.Collections.Generic;

namespace ImplementingLinkedList
{
    public class Program
    {

        public static void Main()
        { 
        
            var linkedList = new DoublyLinkedList<int>();

            linkedList.AddHead(1);
            linkedList.AddHead(2);
            linkedList.AddHead(3);
            linkedList.AddTail(4);

            linkedList.ForEach(n => Console.WriteLine(n));

        }

    }
}