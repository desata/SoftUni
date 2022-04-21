using System;

namespace DeckofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            string cardSign = Console.ReadLine();
            int cardSignN = 0;

            if (int.TryParse(cardSign, out cardSignN))
            {

                // int cardSignN = int.Parse(cardSign);

                if (cardSignN >= 2 && cardSignN <= 10)
                {
                    for (int i = 2; i <= cardSignN; i++)
                    {
                        Console.WriteLine(i + " of spades, " + i + " of clubs, " + i + " of hearts, " + i + " of diamonds");
                    }
                }

                // Console.WriteLine(cardSign);
            }
            else if (cardSign == "J")
            {
                for (int i = 2; i <= 10; i++)
                {
                    Console.WriteLine(i + " of spades, " + i + " of clubs, " + i + " of hearts, " + i + " of diamonds");
                }
                Console.WriteLine(cardSign + " of spades, " + cardSign + " of clubs, " + cardSign + " of hearts, " + cardSign + " of diamonds");

                //Console.WriteLine("error");
            }
            else if (cardSign == "Q")
            {
                for (int i = 2; i <= 10; i++)
                {

                    Console.WriteLine(i + " of spades, " + i + " of clubs, " + i + " of hearts, " + i + " of diamonds");
                }
                string cardSignJ = "J";
                Console.WriteLine(cardSignJ + " of spades, " + cardSignJ + " of clubs, " + cardSignJ + " of hearts, " + cardSignJ + " of diamonds");
                Console.WriteLine(cardSign + " of spades, " + cardSign + " of clubs, " + cardSign + " of hearts, " + cardSign + " of diamonds");
                //Console.WriteLine("error");
            }
            else if (cardSign == "K")
            {
                for (int i = 2; i <= 10; i++)
                {

                    Console.WriteLine(i + " of spades, " + i + " of clubs, " + i + " of hearts, " + i + " of diamonds");
                }
                string cardSignJ = "J";
                string cardSignQ = "Q";
                Console.WriteLine(cardSignJ + " of spades, " + cardSignJ + " of clubs, " + cardSignJ + " of hearts, " + cardSignJ + " of diamonds");
                Console.WriteLine(cardSignQ + " of spades, " + cardSignQ + " of clubs, " + cardSignQ + " of hearts, " + cardSignQ + " of diamonds");
                Console.WriteLine(cardSign + " of spades, " + cardSign + " of clubs, " + cardSign + " of hearts, " + cardSign + " of diamonds");

            }
            else if (cardSign == "A")
            {
                for (int i = 2; i <= 10; i++)
                {

                    Console.WriteLine(i + " of spades, " + i + " of clubs, " + i + " of hearts, " + i + " of diamonds");
                }
                string cardSignJ = "J";
                string cardSignQ = "Q";
                string cardSignK = "K";
                Console.WriteLine(cardSignJ + " of spades, " + cardSignJ + " of clubs, " + cardSignJ + " of hearts, " + cardSignJ + " of diamonds");
                Console.WriteLine(cardSignQ + " of spades, " + cardSignQ + " of clubs, " + cardSignQ + " of hearts, " + cardSignQ + " of diamonds");
                Console.WriteLine(cardSignK + " of spades, " + cardSignK + " of clubs, " + cardSignK + " of hearts, " + cardSignK + " of diamonds");
                Console.WriteLine(cardSign + " of spades, " + cardSign + " of clubs, " + cardSign + " of hearts, " + cardSign + " of diamonds");

            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
/*
Write a program that reads a card sign(as a string) from the console and generates and prints all possible cards from a standard deck of 52 cards up to the card with the given sign(without the jokers). 
The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).

The card faces should start from 2 to A(10 is 10).
Print each card face in its four possible suits: clubs, diamonds, hearts and spades.
Input
On the only line, you will receive the sign of the card to which, including, you should print the cards in the deck.
*/