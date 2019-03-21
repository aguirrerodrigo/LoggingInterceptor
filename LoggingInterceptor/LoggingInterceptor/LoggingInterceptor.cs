using System;
using System.Reflection;

namespace LoggingInterceptor
{
    public class LoggingInterceptor<T> : DispatchProxy
    {
        private T instance;

        public void SetInstance(T instance)
        {
            this.instance = instance;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Console.WriteLine($"Executing {targetMethod.Name}...");

            var result = targetMethod.Invoke(instance, args);

            Console.WriteLine($"Finished executing {targetMethod.Name}.");

            return result;
        }

        public static T Decorate(T instance)
        {
            object proxy = Create<T, LoggingInterceptor<T>>();
            ((LoggingInterceptor<T>)proxy).SetInstance(instance);

            return (T)proxy;
        }
    }
}
