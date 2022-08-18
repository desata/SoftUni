using System;

namespace _05
{
    internal class Player
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int goals = 0;
            string winner = "";
            int goalsWinner = 0;


            while (name != "END")
            {
                goals = int.Parse(Console.ReadLine());

                if (goals > goalsWinner)
                {
                    goalsWinner = goals;
                    winner = name;
                }
                if (goals >= 10)
                {
                    break;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{winner} is the best player!");
            if (goalsWinner >= 3)
            {
                Console.WriteLine($"He has scored {goalsWinner} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {goalsWinner} goals.");
            }
            

        }
    }
}
