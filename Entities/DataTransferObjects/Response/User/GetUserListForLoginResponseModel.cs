﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Response.User
{
    public class GetUserListForLoginResponseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string RoleName { get; set; }
    }
}
