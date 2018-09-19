using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IO.Netty.Util.Concurrent
{
    public interface IExecutorService : IExecutor
    {
        void Shutdown();
        IList<IRunnable> ShutdownNow();
        bool IsShutdown();
        bool isTerminated();
        bool awaitTermination(long timeout, TimeUnit unit);
        Task<T> Submit<T>(Func<T> task);
        Task<T> Submit<T>(IRunnable task, T result);
        Task Submit<T>(IRunnable task);
        IList<Task<T>> InvokeAll<T>(IList<Func<T>> tasks);
        IList<Task<T>> InvokeAll<T>(IList<Func<T>> tasks, long timeout, TimeUnit unit);
        Task<T> InvokeAny<T>(Func<T> task);
        Task<T> InvokeAny<T>(Func<T> task, long timeout, TimeUnit unit);
    }
}
