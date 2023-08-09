using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Response.Rent
{
    public class GetRentWithBookResponseModel
    {
        public string UserName { get; set; }
        public string BookName { get; set; }
        public string IssueDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
