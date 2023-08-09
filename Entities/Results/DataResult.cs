using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Results
{
    public class DataResult<T> : Result
    {
        public T? Data { get; set; }
    }
}
