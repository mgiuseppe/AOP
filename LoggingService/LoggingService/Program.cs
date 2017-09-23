using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService
{
    class Program
    {
        static void Main(string[] args)
        {
            var srv = ServiceFactory.Create<MyService>();

            Console.WriteLine(srv.GetAll());
            Console.WriteLine(srv.GetById(1));
            srv.Update(2);

            Console.ReadLine();
        }
    }
}
