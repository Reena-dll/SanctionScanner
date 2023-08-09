using Entities.Models;
using Repositories.Contracts;
using Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RepositoryContext _repositoryDbContext;
        public RoleRepository(RepositoryContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public Role GetRoleByName(string name)
        {
            return _repositoryDbContext.Roles.Where(x => x.Name == name && !x.IsDeleted).FirstOrDefault();
        }

        public Role GetRoleById(int id)
        {
            return _repositoryDbContext.Roles.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();
        }

        public List<Role> GetAllRole()
        {
            return _repositoryDbContext.Roles.Where(x => !x.IsDeleted).ToList();
        }
    }
}
