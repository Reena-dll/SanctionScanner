using Entities.DataTransferObjects.Request.Account;
using Entities.DataTransferObjects.Response.User;
using Entities.Models;
using Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<DataResult<List<GetUserListForLoginResponseModel>>> GetUserListForLogin();
        Task<DataTableResult<List<GetAllUserListResponse>>> GetAllUserList();
        Task<DataResult<GetTokenResponseModel>> Login(LoginRequestModel model);

    }
}
