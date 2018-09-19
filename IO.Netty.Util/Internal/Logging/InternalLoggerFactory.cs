using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Netty.Util.Internal.Logging
{
    public abstract class InternalLoggerFactory
    {
        private static volatile InternalLoggerFactory defaultFactory;

        private static InternalLoggerFactory NewDefaultFactory(string name)
        {
            return new Log4NetFactory();
        }

        public static InternalLoggerFactory GetDefaultFactory()
        {
            if (defaultFactory == null)
            {
                return NewDefaultFactory("");
            }
            return defaultFactory;
        }

        public static void SetDefaultFactory(InternalLoggerFactory defaultFactory)
        {
            if (defaultFactory == null)
            {
                throw new ArgumentNullException("defaultFactory");
            }
            InternalLoggerFactory.defaultFactory = defaultFactory;
        }


        public static IInternalLogger getInstance(Type type)
        {
            return getInstance(type.Name);
        }


        public static IInternalLogger getInstance(string name)
        {
            return GetDefaultFactory().newInstance(name);
        }

        protected abstract IInternalLogger newInstance(string name);
    }
}
