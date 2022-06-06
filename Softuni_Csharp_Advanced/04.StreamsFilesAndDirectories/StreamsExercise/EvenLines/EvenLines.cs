
namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            //throw new NotImplementedException();
            StreamReader reader = new StreamReader(inputFilePath);
            StringBuilder sb = new StringBuilder();
            char[] symbols = {'-', ',', '.', '!', '?'};

            int counter = 0;
            while (true)
            {
                string result = reader.ReadLine();

                if (result == null)
                {
                    break;
                }
                if (counter %2 == 0)
                {
                    foreach (var symbol in symbols)
                    {
                        result = result.Replace(symbol, '@');
                    }
                    result = String.Join(" ", result.Split().Reverse());

                    sb.AppendLine(result);
                    counter++;
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
