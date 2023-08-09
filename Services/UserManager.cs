using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Request.Account;
using Entities.DataTransferObjects.Response.User;
using Entities.Enum;
using Entities.Models;
using Entities.Results;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Extensions;
using Services.Contracts;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public UserManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper )
        {
            _manager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DataTableResult<List<GetAllUserListResponse>>> GetAllUserList()
        {
            var response = new DataTableResult<List<GetAllUserListResponse>>();

            var list = await _manager.User.GetAllUserList();
            response.Data.Data = list.Adapt<List<GetAllUserListResponse>>();
            response.Data.TotalCount = list.Count();
            response.Data.PageNumber = 1;

            return response;
        }

        public async Task<DataResult<List<GetUserListForLoginResponseModel>>> GetUserListForLogin()
        {
            var response = new DataResult<List<GetUserListForLoginResponseModel>>();

            response.Data = await _manager.User.GetUserListForLogin();

            return response;
        }

        public async Task<DataResult<GetTokenResponseModel>> Login(LoginRequestModel model)
        {
            var result = new DataResult<GetTokenResponseModel>();
            _logger.LogInfo("user service login control");
            var user = await _manager.User.GetUserByEmail(model.Email);
            if (user is null)
            {
                result.Error.ErrorMessage = "Kullanıcı bulunamadı";
                return result;
            }
            _logger.LogInfo("user service login control 2 user is not null");
            var findUser = await _manager.User.UserGetRoleById(user.Id);
            _logger.LogInfo("user service login control 3 finduser is not null");


            if (user.Password == model.Password)
            {
                #region GenerateToken
                var resultUser = new GetTokenResponseModel
                {
                    User = new UserProfile
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        CurrentUserId = user.Id,
                        FullName = $"{user.Name} {user.LastName}",
                        RoleName = findUser?.UserRoles?.FirstOrDefault()?.Role?.Name,
                    }
                };

                //resultUser.Token = AuthHelper.GenerateToken(user);
                resultUser.ExpireTime = DateTime.Now.AddHours(6).ToString("yyyy-MM-ddTHH:mm:ssZ");

                var name = $"{user.Name} {user.LastName}";
                var roleList = resultUser.User.RoleName;
                switch (roleList)
                {
                    case "SuperAdmin":
                        resultUser.RightList = _manager.RoleClaim.GetRoleClaimsByRoleId((int)GeneralEnum.RoleType.SuperAdmin).Select(x => x.ClaimValue).ToList();
                        break;
                    case "Admin":
                        resultUser.RightList = _manager.RoleClaim.GetRoleClaimsByRoleId((int)GeneralEnum.RoleType.Admin).Select(x => x.ClaimValue).ToList();
                        break;
                    default:
                        resultUser.RightList = _manager.RoleClaim.GetRoleClaimsByRoleId((int)GeneralEnum.RoleType.User).Select(x => x.ClaimValue).ToList();
                        break;
                }
                resultUser.Token = AuthHelper.GenerateToken(user);
                result.Data = resultUser;
                #endregion
            }
            else
            {
                result.Error.ErrorMessage = "Kullanıcı mail veya şifre yanlış";
                return result;
            }
            return result;
        }
    }
}
