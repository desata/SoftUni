using Loggers.Layouts;
using Loggers.ReportInfo;

namespace Loggers.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel LogLevel { get; set; }

        void Append(string dateTime, ReportLevel reportInfo, string message);
    }
}
