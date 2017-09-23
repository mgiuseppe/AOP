using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService
{
    public class StandardResponse<T>
    {
        public T output;
        public int status;
    }
}
