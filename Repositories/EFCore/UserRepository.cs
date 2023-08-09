using Entities.DataTransferObjects.Request.User;
using Entities.DataTransferObjects.Response;
using Entities.DataTransferObjects.Response.User;
using Entities.Enum;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;


namespace Repositories.EFCore
{
    public class UserRepository : IUserRepository
    {
        private readonly RepositoryContext _repositoryDbContext;

        public UserRepository(RepositoryContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public async Task<List<User>> GetAllUserByFilter(GetAllUserFilterRequest request)
        {
            var userList = await (from user in _repositoryDbContext.Users
                                  where user.UserRoles.FirstOrDefault().Role.Id == (int)request.RoleType && user.IsDeleted == false                                
                                  select user).ToListAsync();

            return userList;
        }
        public async Task<User> UserGetById(int Id)
        {
            return await _repositoryDbContext.Users.Where(x => x.Id == Id && x.IsDeleted == false).FirstOrDefaultAsync();
        }

        public User UserGetByIdNonAsync(int Id)
        {

            return _repositoryDbContext.Users.Where(x => x.Id == Id && x.IsDeleted == false).FirstOrDefault();
        }
        public async Task<List<User>> GetAllUserByRole(GeneralEnum.RoleType role)
        {
            return await _repositoryDbContext.Users.Where(x => x.UserRoles.FirstOrDefault().Role.Id == (int)role && x.IsDeleted == false).ToListAsync();

        }
        public async Task<List<KeyValueResponseModel>> GetAll()
        {
            return await (from user in _repositoryDbContext.Users
                          where user.IsDeleted == false
                          select new KeyValueResponseModel()
                          {
                              Key = user.Id,
                              Value = $"{user.Name} {user.LastName}",
                          }).ToListAsync();
        }
        public async Task<List<GetUserListForLoginResponseModel>> GetUserListForLogin()
        {
            var list = await _repositoryDbContext.Users.Where(x => !x.IsDeleted).Include(x => x.UserRoles).ThenInclude(x => x.Role).ToListAsync();

            var resList = list.Select(c => new GetUserListForLoginResponseModel
            {
                Key = $"{c.UserName} - {c.UserRoles?.FirstOrDefault()?.Role?.Name}",
                RoleName = c.UserRoles?.FirstOrDefault()?.Role?.Name ?? "",
                Value = c.Email
            }).ToList();

            return resList;
        }
        public async Task<List<User>> GetAllSuperUser()
        {
            return await _repositoryDbContext.Users.Where(x => !x.IsDeleted && x.UserRoles.FirstOrDefault().Role.Id == (int)GeneralEnum.RoleType.SuperAdmin).ToListAsync();
        }
        public async Task<User> UserGetByPersonelNumber(string personnelNumber)
        {
            return await _repositoryDbContext.Users.Where(x => x.PersonnelNumber == personnelNumber && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<User> UserGetByUserName(string username)
        {
            return await _repositoryDbContext.Users.Where(x => x.UserName == username && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmail(string Email)
        {
            return await _repositoryDbContext.Users.Where(x => x.Email == Email && !x.IsDeleted).FirstOrDefaultAsync();
        }
      
        public async Task<User> UserGetRoleById(int Id)
        {
            return await _repositoryDbContext.Users.Where(x => x.Id == Id && x.IsDeleted == false).Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync();
        }
        public async Task<User> UserGetRoleByEmail(string Email)
        {
            return await _repositoryDbContext.Users.Where(x => x.Email == Email && x.IsDeleted == false).Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync();
        }

      
        public async Task<List<GetAllUserListResponse>> GetAllUserList()
        {
            var getUser = await _repositoryDbContext.Users.Where(x => x.IsDeleted == false).Select(x => new GetAllUserListResponse
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                UserName = x.UserName,
                Email = x.Email,
                PersonnelNumber = x.PersonnelNumber,

            }).ToListAsync();

            return getUser;
        }

        public async Task<List<User>> GetUserListByRole(GetUserListByTypeRequest request)
        {
            var data = await(from user in _repositoryDbContext.Users
                             select user).ToListAsync();

            return data;
        }
    }
}

