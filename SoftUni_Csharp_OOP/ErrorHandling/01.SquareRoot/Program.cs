using System;

namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                double squareRoot = CalcSquareRoot(); // Calculate square root, exceptions can be thrown
                Console.WriteLine(squareRoot);
            }
            // List of possible exceptions
            catch (ArgumentNullException) // If input is "null" - try with "Ctrl + Z"
            {
                Console.WriteLine("Invalid number.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number.");
            }
            catch (FormatException) // If input is different format, like "double" or "float"
            {
                Console.WriteLine("Invalid number.");
            }
            catch (OverflowException) // If input is negative number
            {
                Console.WriteLine("Invalid number.");
            }
            catch (Exception)// If any of the above listed "exceptions" can't handle, this takes care
            {
                Console.WriteLine("Invalid number.");
            }
            finally // No matter what, this is executed
            {
                Console.WriteLine("Goodbye.");
            }
        }

        /// <summary>
        /// Calculate square root of input integer
        /// </summary>
        private static double CalcSquareRoot()
        {
            double squareRoot;
            uint inputNumber;

           
            inputNumber = uint.Parse(Console.ReadLine()); // This operation can throw exceptions

            squareRoot = Math.Sqrt(inputNumber);

            return squareRoot;
        }

    }
}

