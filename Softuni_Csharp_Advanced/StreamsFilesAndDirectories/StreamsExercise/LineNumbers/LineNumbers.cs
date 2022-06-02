namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);
            char[] symbols = { '-', ',', '.', '!', '?', '\'' };

            using (reader)
            {
                using (writer)
                {

                    var line = reader.ReadLine();
                    int index = 1;

                    while (line != null)
                    {
                        int counterpunct = 0;
                        int countChar = 0;

                        foreach (char symbol in line)
                        {
                            counterpunct = line.Count(Char.IsPunctuation);
                            countChar = line.Count(Char.IsLetter);
                        }
                        writer.WriteLine($"Line {index}: {line} ({countChar}) ({counterpunct})");
                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
