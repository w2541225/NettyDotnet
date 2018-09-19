using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Netty.Util.Internal.Logging
{
    [Serializable]
    public abstract class AbstractInternalLogger : IInternalLogger
    {
        private static readonly long serialVersionUID = -6382972526573193470L;

        static readonly string EXCEPTION_MESSAGE = "Unexpected exception:";

        private readonly string name;

        public string Name { get => name; }



        protected AbstractInternalLogger(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            this.name = name;
        }

        public bool IsEnabled(InternalLogLevel level)
        {
            switch (level)
            {
                case InternalLogLevel.Trace:
                    return IsTraceEnabled;
                case InternalLogLevel.Debug:
                    return IsDebugEnabled;
                case InternalLogLevel.Info:
                    return IsInfoEnabled;
                case InternalLogLevel.Warn:
                    return IsWarnEnabled;
                case InternalLogLevel.Error:
                    return IsErrorEnabled;
                default:
                    throw new Exception();
            }
        }

        public abstract bool IsTraceEnabled { get; }
        public abstract bool IsDebugEnabled { get; }
        public abstract bool IsInfoEnabled { get; }
        public abstract bool IsWarnEnabled { get; }
        public abstract bool IsErrorEnabled { get; }

        public abstract void Trace(string msg);
        public abstract void Trace(string format, object arg);
        public abstract void Trace(string format, object argA, object argB);
        public abstract void Trace(string format, params object[] arguments);
        public abstract void Trace(string msg, Exception e);


        public abstract void Debug(string msg);
        public abstract void Debug(string format, object arg);
        public abstract void Debug(string format, object argA, object argB);
        public abstract void Debug(string format, params object[] arguments);
        public abstract void Debug(string msg, Exception e);


        public abstract void Info(string msg);
        public abstract void Info(string format, object arg);
        public abstract void Info(string format, object argA, object argB);
        public abstract void Info(string format, params object[] arguments);
        public abstract void Info(string msg, Exception e);

        public abstract void Warn(string msg);
        public abstract void Warn(string format, object arg);
        public abstract void Warn(string format, object argA, object argB);
        public abstract void Warn(string format, params object[] arguments);
        public abstract void Warn(string msg, Exception e);

        public abstract void Error(string msg);
        public abstract void Error(string format, object arg);
        public abstract void Error(string format, object argA, object argB);
        public abstract void Error(string format, params object[] arguments);
        public abstract void Error(string msg, Exception e);



        public void Trace(Exception e)
        {
            Trace(EXCEPTION_MESSAGE, e);
        }


        public void Debug(Exception e)
        {
            Debug(EXCEPTION_MESSAGE, e);
        }



        public void Info(Exception e)
        {
            Info(EXCEPTION_MESSAGE, e);
        }


        public void Warn(Exception e)
        {
            Warn(EXCEPTION_MESSAGE, e);
        }


        public void Error(Exception e)
        {
            Error(EXCEPTION_MESSAGE, e);
        }

        public void Log(InternalLogLevel level, string msg)
        {
            switch (level)
            {
                case InternalLogLevel.Trace:
                    Trace(msg);
                    break;
                case InternalLogLevel.Debug:
                    Debug(msg);
                    break;
                case InternalLogLevel.Info:
                    Info(msg);
                    break;
                case InternalLogLevel.Warn:
                    Warn(msg);
                    break;
                case InternalLogLevel.Error:
                    Error(msg);
                    break;
                default:
                    throw new Exception();
            }
        }

        public void Log(InternalLogLevel level, string format, object arg)
        {
            switch (level)
            {
                case InternalLogLevel.Trace:
                    Trace(format, arg);
                    break;
                case InternalLogLevel.Debug:
                    Debug(format, arg);
                    break;
                case InternalLogLevel.Info:
                    Info(format, arg);
                    break;
                case InternalLogLevel.Warn:
                    Warn(format, arg);
                    break;
                case InternalLogLevel.Error:
                    Error(format, arg);
                    break;
                default:
                    throw new Exception();
            }
        }

        public void Log(InternalLogLevel level, string format, object argA, object argB)
        {
            switch (level)
            {
                case InternalLogLevel.Trace:
                    Trace(format, argA, argB);
                    break;
                case InternalLogLevel.Debug:
                    Debug(format, argA, argB);
                    break;
                case InternalLogLevel.Info:
                    Info(format, argA, argB);
                    break;
                case InternalLogLevel.Warn:
                    Warn(format, argA, argB);
                    break;
                case InternalLogLevel.Error:
                    Error(format, argA, argB);
                    break;
                default:
                    throw new Exception();
            }
        }

        public void Log(InternalLogLevel level, string format, params object[] arguments)
        {
            switch (level)
            {
                case InternalLogLevel.Trace:
                    Trace(format, arguments);
                    break;
                case InternalLogLevel.Debug:
                    Debug(format, arguments);
                    break;
                case InternalLogLevel.Info:
                    Info(format, arguments);
                    break;
                case InternalLogLevel.Warn:
                    Warn(format, arguments);
                    break;
                case InternalLogLevel.Error:
                    Error(format, arguments);
                    break;
                default:
                    throw new Exception();
            }
        }

        public void Log(InternalLogLevel level, string msg, Exception e)
        {
            switch (level)
            {
                case InternalLogLevel.Trace:
                    Trace(msg, e);
                    break;
                case InternalLogLevel.Debug:
                    Debug(msg, e);
                    break;
                case InternalLogLevel.Info:
                    Info(msg, e);
                    break;
                case InternalLogLevel.Warn:
                    Warn(msg, e);
                    break;
                case InternalLogLevel.Error:
                    Error(msg, e);
                    break;
                default:
                    throw new Exception();
            }
        }

        public void Log(InternalLogLevel level, Exception e)
        {
            switch (level)
            {
                case InternalLogLevel.Trace:
                    Trace(e);
                    break;
                case InternalLogLevel.Debug:
                    Debug(e);
                    break;
                case InternalLogLevel.Info:
                    Info(e);
                    break;
                case InternalLogLevel.Warn:
                    Warn(e);
                    break;
                case InternalLogLevel.Error:
                    Error(e);
                    break;
                default:
                    throw new Exception();
            }
        }
        protected object ReadResolve()
        {
            return InternalLoggerFactory.getInstance(name);
        }
    }



}
}
