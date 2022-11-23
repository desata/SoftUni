using Logger.Appenders;
using Logger.LogFile;
using Loggers.Layouts;
using Loggers.ReportInfo;
using System;
using System.IO;

namespace Loggers.Appenders
{
    public class FileAppender : Appender
    {
        private const string filePath = "../../../Output/log.txt";

        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string dateTime, ReportLevel reportInfo, string message)
        {
            string fileMessage = string.Format(this.Layout.Format, dateTime, reportInfo, message);

            LogFile.Write(fileMessage);

            File.AppendAllText(filePath, fileMessage + Environment.NewLine);
        }
    }
}
