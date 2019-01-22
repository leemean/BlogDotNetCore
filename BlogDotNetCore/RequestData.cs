using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDotNetCore
{
    public class RequestData<T> where T: class
    {
        public string type { get; set; }

        public T data { get; set; }
    }
}
