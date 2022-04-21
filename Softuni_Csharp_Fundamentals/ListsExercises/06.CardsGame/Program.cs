using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////You will be given two hands of cards, which will be represented by integers.
            ////Assume each one is held by a different player.
            ////You have to find which one has the winning deck.
            ////You start from the beginning of both hands of cards.
            //Compare the cards from the first deck to the cards from the second deck.
            //The player, who holds the more powerful card on the current iteration,
            //takes both cards and puts them at the back of his hand - the second player's card is placed last,
            //and the first person's card (the winning one) comes after it (second to last).
            //If both players' cards have the same values - no one wins, and the two cards must be removed from both hands.
            //The game is over when only one of the decks is left without any cards.
            //You have to display the result on the console and the sum of the remaining cards:
            //"{First/Second} player wins! Sum: {sum}".

            List<int> deckOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> deckTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;


            while ((deckOne.Count > 0) && (deckTwo.Count > 0))
            {
                int i = 0;

                if (deckOne[i] == deckTwo[i])
                {
                    deckOne.RemoveAt(i);
                    deckTwo.RemoveAt(i);
                    //i--;
                }
                else if (deckOne[i] > deckTwo[i])
                {
                    deckOne.Add(deckTwo[i]);

                    int temp = deckOne[0];
                    for (int j = 0; j < deckOne.Count - 1; j++)
                    {
                        deckOne[j] = deckOne[j + 1];
                    }

                    deckOne[deckOne.Count - 1] = temp;

                    deckTwo.RemoveAt(i);

                }
                else if (deckOne[i] < deckTwo[i])
                {
                    deckTwo.Add(deckOne[i]);

                    int temp = deckTwo[0];
                    for (int j = 0; j < deckTwo.Count - 1; j++)
                    {
                        deckTwo[j] = deckTwo[j + 1];
                    }

                    deckTwo[deckTwo.Count - 1] = temp;

                    deckOne.RemoveAt(i);

                }


            }
            if (deckOne.Count == 0)
            {
                for (int i = 0; i < deckTwo.Count; i++)
                {
                    sum += deckTwo[i];

                }
                Console.WriteLine($"Second player wins! Sum: {sum}");

            }
            else if (deckTwo.Count == 0)
            {
                for (int i = 0; i < deckOne.Count; i++)
                {
                    sum += deckOne[i];

                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }

        }
    }
}
