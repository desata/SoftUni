using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader("inputFilePath");
            StreamWriter writer = new StreamWriter("outputFilePath");

            using (reader)
            {
                using (writer)
                {
                    int index = 0;
                    var line = reader.ReadLine();

                    while (line != null)
                    {

                        if (index % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        index++;
                        line = reader.ReadLine();
                    }
                }

            }
        }
    }
}