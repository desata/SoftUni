        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;

class Program
    {
    static void Main()
    {
        string str = "";
        if (str == null)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}
/*
 * The Chinese zodiac assigns an animal to year according to the following table:

Year	Animal		Year	Animal
2000	Dragon		2006	Dog
2001	Snake		2007	Pig
2002	Horse		2008	Rat
2003	Sheep		2009	Ox
2004	Monkey		2010	Tiger
2005	Rooster		2011	Hare
Write a program that determines the zodiac sign for a particular year. Note that the cycle repeats itself, so 2012 will be the year of the Dragon again.
Input
On the first line, you will receive the year
Output
On the only line of output, print the corresponding zodiac Sign
Input
2000
Output
Dragon
Input
1975
Output
Hare
*/