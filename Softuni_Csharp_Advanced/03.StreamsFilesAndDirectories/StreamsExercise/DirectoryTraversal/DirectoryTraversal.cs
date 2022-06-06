namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*");
            var filesInfo = new Dictionary<string, Dictionary<string, double>>();

            foreach (var filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string fileExtension = Path.GetExtension(filePath);
                double fileSize = new FileInfo(filePath).Length / 1024.0;

                if (!filesInfo.ContainsKey(fileExtension))
                {
                    filesInfo.Add(fileExtension, new Dictionary<string,double>());
                }

                filesInfo[fileExtension].Add(fileName, fileSize);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in filesInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.AppendLine(item.Key);

                foreach (var file in item.Value.OrderBy(x => x.Value))
                { 
                    sb.AppendLine($"--{file.Key} - {file.Value:F3}kb");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            // save as report.txt on desktop
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            File.WriteAllText(path, textContent);
        }
    }
}
