using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Results
{
    public class DataTableResult<T> : Result
    {
        public DataResponse<T> Data { get; set; } = new DataResponse<T>();
    }
    public class DataResponse<T>
    {
        public T Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }  
        public DateTime Timestamp { get; set; } = DateTime.Now.ToLocalTime();
        public Guid TransactionId { get; set; } = Guid.NewGuid();
  
    }
}
