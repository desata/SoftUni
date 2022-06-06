namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            { 
                Directory.Delete(outputPath);
            }
            else
            {
                Directory.CreateDirectory(outputPath);
            }

            string[] files = Directory.GetFiles(inputPath);

            foreach (string file in files)
            { 
                string fileName = outputPath + "\\" + Path.GetFileName(file);
            File.Copy(file, fileName);

            }
        }
    }
}
