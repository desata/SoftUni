using Loggers.Appenders;
using Loggers.ReportInfo;
using System;
using System.Collections.Generic;

namespace Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = new List<IAppender>();

            this.Appenders.AddRange(appenders);
        }

        public List<IAppender> Appenders { get; }


        public void Critical(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Critical, message);           
        }


        public void Error(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Warning, message);
        }


        private void Log(string dateTime, ReportLevel logLevel, string message)
        {
            foreach (var appender in Appenders)
            {
                if (logLevel >= appender.LogLevel)
                {
                    appender.Append(dateTime, logLevel, message);
                }                
            }
        }
    }
}
