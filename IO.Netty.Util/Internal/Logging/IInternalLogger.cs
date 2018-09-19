using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Netty.Util.Internal.Logging
{
    public interface IInternalLogger
    {
        string Name { get; }
        bool IsTraceEnabled { get; }
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }

        void Trace(string msg);
        void Trace(string format, object arg);
        void Trace(string format, object argA, object argB);
        void Trace(string format, params object[] arguments);
        void Trace(string msg, Exception e);
        void Trace(Exception e);

        void Debug(string msg);
        void Debug(string format, object arg);
        void Debug(string format, object argA, object argB);
        void Debug(string format, params object[] arguments);
        void Debug(string msg, Exception e);
        void Debug(Exception e);

        void Info(string msg);
        void Info(string format, object arg);
        void Info(string format, object argA, object argB);
        void Info(string format, params object[] arguments);
        void Info(string msg, Exception e);
        void Info(Exception e);

        void Warn(string msg);
        void Warn(string format, object arg);
        void Warn(string format, object argA, object argB);
        void Warn(string format, params object[] arguments);
        void Warn(string msg, Exception e);
        void Warn(Exception e);

        void Error(string msg);
        void Error(string format, object arg);
        void Error(string format, object argA, object argB);
        void Error(string format, params object[] arguments);
        void Error(string msg, Exception e);
        void Error(Exception e);

        bool IsEnabled(InternalLogLevel level);
        void Log(InternalLogLevel level, string msg);
        void Log(InternalLogLevel level, string format, object arg);
        void Log(InternalLogLevel level, string format, object argA, object argB);
        void Log(InternalLogLevel level, string format, params object[] arguments);
        void Log(InternalLogLevel level, string msg, Exception e);
        void Log(InternalLogLevel level, Exception e);

    }

    public enum InternalLogLevel
    {
        /**
         * 'TRACE' log level.
         */
        Trace,
        /**
         * 'DEBUG' log level.
         */
        Debug,
        /**
         * 'INFO' log level.
         */
        Info,
        /**
         * 'WARN' log level.
         */
        Warn,
        /**
         * 'ERROR' log level.
         */
        Error
    }
}
