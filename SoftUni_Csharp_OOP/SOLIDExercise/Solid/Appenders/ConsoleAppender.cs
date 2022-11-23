using Logger.Appenders;
using Loggers.Layouts;
using Loggers.ReportInfo;
using System;
using System.Globalization;

namespace Loggers.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportInfo, string message)
        {
            string ConsoleMessage = string.Format(this.Layout.Format, dateTime, reportInfo, message);

            Console.WriteLine(ConsoleMessage);
        }
    }
}
