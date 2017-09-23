using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService
{
    public class ServiceFactory
    {
        public static IService Create<T> () where T : class, IService
        {
            var requestedObject = Activator.CreateInstance<T>();
            var proxy = new LoggingProxy<IService>(requestedObject);
            return proxy.GetTransparentProxy() as IService;
        }
    }
}
