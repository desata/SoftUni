using System;

namespace DataTypesMore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            You will receive input until you receive "END". Find what data type is the input. Possible data types are:
            Integer 
                Floating point 
                Characters
                Boolean
                Strings
            Print the result in the following format: "{input} is {data type} type"
            */
            string input = "";
            string dataType = string.Empty;


            while (input != "END")
            {
                input = Console.ReadLine();
                int convertInt;
                double convertDouble;
                bool convertBool;
                char convertChar;               
                
                
                //int
                if (int.TryParse(input, out convertInt))
                {
                    dataType = "integer";
                }
                //float
                else if (double.TryParse(input, out convertDouble))
                {
                    dataType = "floating point";
                }
                //bool
                else if (bool.TryParse(input, out convertBool))
                {
                    dataType = "boolean"; 
                }
                //char
                else if (char.TryParse(input, out convertChar))
                {
                    dataType = "character";
                }
                //END
                else if (input == "END")
                {
                    break;
                }
                else
                {
                    dataType = "string";
                }
                Console.WriteLine($"{input} is {dataType} type");
            }
            
        }
    }
}
