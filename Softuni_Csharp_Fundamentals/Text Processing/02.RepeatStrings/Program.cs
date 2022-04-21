using System;
using System.Text;

namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Create a Program That Reads an Array of Strings.
            //Each String is Repeated N Times, Where N is the length of the String.
            //Print the Concatenated String.

            string[] array = Console.ReadLine().Split();

            //foreach (var ar in array)
            //{
            //for (int i = 0; i < ar.Length; i++)
            //{
            //    Console.Write(string.Join("", ar));
            //}


            //}
            StringBuilder result = new StringBuilder();

            foreach (var ar in array)
            {
                int count = ar.Length;
                for (int i = 0; i < count; i++)
                {
                    result.Append(ar);



                }
;
            }
            Console.Write(result);
        }
    }
}
