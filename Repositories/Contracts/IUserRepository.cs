
using Entities.DataTransferObjects.Request.User;
using Entities.DataTransferObjects.Response;
using Entities.DataTransferObjects.Response.User;
using Entities.Enum;
using Entities.Models;

namespace Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> UserGetById(int Id);
        User UserGetByIdNonAsync(int Id);
        /// <summary>
        /// Superuser filtreye gore veya tüm data donuyor (rol göre kontrol eksik)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<User>> GetAllUserByFilter(GetAllUserFilterRequest request);
        Task<List<User>> GetAllUserByRole(GeneralEnum.RoleType role);
        /// <summary>
        /// Org. admin filtreye gore veya tüm data donuyor
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <summary>
        /// Org. admin ve user filtreye gore veya tüm data donuyor
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<User>> GetUserListByRole(GetUserListByTypeRequest request);

        /// <summary>
        /// Tüm silinmemiş user kayıtlarının listesi döner.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<KeyValueResponseModel>> GetAll();
        Task<List<GetUserListForLoginResponseModel>> GetUserListForLogin();
        Task<List<User>> GetAllSuperUser();
        Task<User> UserGetByPersonelNumber(string personnelNumber);
        Task<User> UserGetByUserName(string username);
        Task<User> UserGetRoleById(int Id);
        Task<User> UserGetRoleByEmail(string Email);
        Task<User> GetUserByEmail(string Email);
        Task<List<GetAllUserListResponse>> GetAllUserList();


    }
}
