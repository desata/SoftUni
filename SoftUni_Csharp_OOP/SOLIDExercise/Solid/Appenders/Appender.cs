using Loggers.Appenders;
using Loggers.Layouts;
using Loggers.ReportInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel LogLevel { get ; set ; }

        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public abstract void Append(string dateTime, ReportLevel reportInfo, string message);
    }
}
