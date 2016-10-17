using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Log
{
    public interface ILogger
    {
        void Fatal(object message);
        void Fatal(object message, Exception exception);
        void Error(object message);
        void Error(object message, Exception exception);
        void Warn(object message);
        void Warn(object message, Exception exception);
        void Info(object message);
        void Info(object message, Exception exception);
        void Debug(object message);
        void Debug(object message, Exception exception);

        bool IsFatalEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsDebugEnabled { get; }
    }
}
