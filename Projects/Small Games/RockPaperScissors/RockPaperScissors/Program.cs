using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.WriteLine("Rock, Paper, Scissors! Go!");

            List<string> computerSet = new List<string>()
            {
                "Rock", "Paper", "Scissors"

            };

            string myChoice = string.Empty;
            string computerChoice = string.Empty;

            bool exitOfGame = false;
            int invalidInputs = 0;
            int myWins = 0;
            int computerWins = 0;

            while (myWins < 2 || computerWins < 2)
            {
                if (invalidInputs >= 3)
                {
                    exitOfGame = true;
                    break;
                }

                Console.Write("Your turn: ");
                myChoice = Console.ReadLine();
                int index = random.Next(0, computerSet.Count);
                computerChoice = computerSet[index];
                myChoice = myChoice.ToLower();

                if ((myChoice != "rock") || (myChoice != "scissors") || (myChoice != "paper"))
                {
                    Console.WriteLine($"Invalid input!");
                    Console.WriteLine();
                    invalidInputs++;
                    continue;
                }

                Console.WriteLine($"Computer choose {computerChoice}.");
                computerChoice = computerChoice.ToLower();

                if (myChoice == computerChoice)
                {
                    Console.WriteLine($"You both choose {myChoice}. Try again!");
                }
                else if ((myChoice == "rock" && computerChoice == "scissors") || (myChoice == "scissors" && computerChoice == "paper"))
                {
                    myWins++;
                    Console.WriteLine($"{myChoice} beats {computerChoice}!");
                    Console.WriteLine("You win!");
                }
                else
                {
                    computerWins++;
                    Console.WriteLine($"{computerChoice} beats {myChoice}!");
                    Console.WriteLine("Computer wins!");
                }
                Console.WriteLine();

            }

            string winner = string.Empty;

            if (exitOfGame == true)
            {
                Console.WriteLine("You don't want to play, do you?");
                Console.WriteLine("Game over!!!");
                winner = "No one is";


            }
            else if (myWins > computerWins)
            {
                winner = "Congratulations! You are";
            }
            else
            {
                winner = "Nice try, but computer is";
            }
            Console.WriteLine();
            Console.WriteLine($"{winner} the big winner!");
        }
    }
}
