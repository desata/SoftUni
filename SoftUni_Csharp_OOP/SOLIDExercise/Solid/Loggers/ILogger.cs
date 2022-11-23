using Loggers.Appenders;
using System.Collections.Generic;

namespace Loggers
{
    public interface ILogger
    {
        public List<IAppender> Appenders { get; }

        //Info > Warning > Error > Critical > Fatal.

        void Info(string dateTime, string message);
        void Warning(string dateTime, string message);
        void Error(string dateTime, string message);
        void Critical(string dateTime, string message);
        void Fatal(string dateTime, string message);
    }
}
