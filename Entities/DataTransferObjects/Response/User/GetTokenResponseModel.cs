using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Response.User
{
    public class GetTokenResponseModel
    {
        public string Token { get; set; }
        public UserProfile User { get; set; }
        public string ExpireTime { get; set; }
        public List<string> RightList { get; set; }
    }
}
