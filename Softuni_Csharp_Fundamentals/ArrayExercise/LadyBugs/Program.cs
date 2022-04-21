using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine()); // въвежда се размер на полето
            int[] ladyBugsInField = new int[fieldSize]; // създава се поле по въведения размер
            int[] initialIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray(); // въвеждат се начални позиции на калинки

            foreach (var initialIndex in initialIndexes) // провека дали въведените позиции на калинки са в полето
            {
                if (initialIndex >= 0 && initialIndex < fieldSize)
                {
                    ladyBugsInField[initialIndex] = 1;
                }
            }

            string command = string.Empty; // празен стринг за инструкция
            while ((command = Console.ReadLine()) != "end") // въвеждане и проверка на инструкцията
            {
                int start = int.Parse(command.Split()[0]); // начална позиция
                int moveStep = int.Parse(command.Split()[2]); // стъпка за преместване
                string direction = command.Split()[1]; // посока на движение

                if (start >= 0 && start < fieldSize) // проверка дали началната позиция е в полето
                {
                    if (ladyBugsInField[start] == 0 || moveStep == 0) // проверка дали има/няма калинка на началната позиция или има/няма стъпка за преместване
                    {
                        continue;
                    }
                    else
                    {
                        ladyBugsInField[start] = 0; // премахва калинката от началната позиция

                        if (direction == "left") // проверка за посока наляво
                        {
                            if (start - moveStep >= 0 && start - moveStep < fieldSize) // проверка дали след преместване калинката ще бъде в полето
                            {
                                for (int i = start - moveStep; i < fieldSize && i >= 0; i -= moveStep) // проверка дали е свободна крайната позицията 
                                {
                                    if (ladyBugsInField[i] == 0) // ако е свободна
                                    {
                                        ladyBugsInField[i] = 1; // премества калинката 
                                        break; // и излиза от проверката
                                    }
                                }
                            }
                        }
                        else if (direction == "right") // проверка за посока надясно
                        {
                            if (start + moveStep >= 0 && start + moveStep < fieldSize) // проверка дали след преместване калинката ще бъде в полето
                            {
                                for (int i = start + moveStep; i < fieldSize && i >= 0; i += moveStep) // проверка дали е свободна крайната позицията
                                {
                                    if (ladyBugsInField[i] == 0) // ако е свободна
                                    {
                                        ladyBugsInField[i] = 1; // премества калинката
                                        break; // и излиза от проверката
                                    }
                                }
                            }
                        }
                        else // ако посоката е различна от "наляво" или "нядясно"
                        {
                            ladyBugsInField[start] = 1; // калинката се връща на началната позиция
                            continue; // повтаря while цикъла
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", ladyBugsInField)); // принтира полето с калинки
        }
    }
}