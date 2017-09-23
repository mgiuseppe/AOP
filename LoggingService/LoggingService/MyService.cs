using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService
{
    public class MyService : IService
    {
        public IEnumerable<int> GetAll()
        {
            return Enumerable.Range(1, 10);
        }

        public int GetById(int id)
        {
            return id;
        }

        public void Update(int id)
        {
            Console.WriteLine("i'm updating yeahhh");
        }
    }
}
