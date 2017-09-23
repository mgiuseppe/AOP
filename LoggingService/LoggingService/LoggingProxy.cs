using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService
{
    public class LoggingProxy<T> : RealProxy
    {
        private readonly T _decorated;

        /// <summary>
        /// Conserva l'oggetto da decorare e invoca il costruttore di RealProxy 
        /// in modo da costruire un proxy che rappresenti un oggetto remoto di tipo T
        /// </summary>
        public LoggingProxy(T decorated) : base(typeof(T))
        {
            _decorated = decorated;
        }

        /// <summary>
        /// Metodo che viene richiamato
        /// </summary>
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            
            try
            {
                Log("Before Invoking {0}", methodInfo.Name);

                var result = methodInfo.Invoke(_decorated, methodCall.InArgs);

                Log("After Invoking {0}", methodInfo.Name);
                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch(Exception e)
            {
                Log("Exception {0} invoking {1}", e, methodCall.MethodName);
                return new ReturnMessage(e, methodCall);
            }
        }

        private void Log(string msg, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, args);
            Console.ResetColor();
        }
    }
}
