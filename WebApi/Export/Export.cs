using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Export
{
    public class Export<T>
    {
        public IEnumerable<T> obj { get; set; }
    }
}
