using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.LogFile
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
