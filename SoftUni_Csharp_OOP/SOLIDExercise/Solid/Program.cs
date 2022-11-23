using Logger.Layouts;
using Logger.LogFile;
using Loggers.Appenders;
using Loggers.Layouts;
using System;

namespace Loggers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);

            consoleAppender.LogLevel = ReportInfo.ReportLevel.Error;

            var logger = new Logger(consoleAppender);
           

            logger.Info("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

        }
    }
}
