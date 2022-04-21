using System;

namespace _02.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The triangle may be constructed in the following manner:
            //In row 0 (the topmost row), there is a unique nonzero entry
            //1. Each entry of each subsequent row is constructed by adding the number above and to the left with the number above and to the right, treating blank entries as 0.
            //For example, the initial number in the first (or any other) row is 1
            //(the sum of 0 and 1), whereas the numbers 1 and 3 in the third row are added to produce the number 4 in the fourth row.

            int n = int.Parse(Console.ReadLine());



        }
    }
}
