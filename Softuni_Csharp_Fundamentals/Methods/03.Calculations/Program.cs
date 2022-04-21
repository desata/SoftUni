using System;

namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            //int result = 0;

            GetAction(action,firstNumber,secondNumber);
           // Console.WriteLine(result);
        }

        static void GetAction(string action, int firstNumber, int secondNumber)
            {
            int result = 0;
            if (action == "add")
                {
                    result = firstNumber + secondNumber;
                    
                }
            else if (action == "subtract")
                {
                    result = firstNumber - secondNumber;
                    
                }
            else if (action == "multiply")
                {
                    result = firstNumber * secondNumber;
                    
                }
            else if (action == "divide")
                {
                    result = firstNumber / secondNumber;
                   
                }
                Console.WriteLine(result);
                return;
            }
        
    }
}
