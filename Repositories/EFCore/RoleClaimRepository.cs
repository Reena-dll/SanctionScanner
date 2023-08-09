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
    public class RoleClaimRepository : IRoleClaimRepository
    {
        private readonly RepositoryContext _repositoryDbContext;

        public RoleClaimRepository(RepositoryContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public List<RoleClaimsMapping> GetRoleClaims()
        {
            return _repositoryDbContext.RoleClaimsMapping.Where(x => !x.IsDeleted).ToList();
        }

        public RoleClaimsMapping GetRoleClaimsById(int id)
        {
            return _repositoryDbContext.RoleClaimsMapping.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();
        }

        public RoleClaimsMapping GetRoleClaimsByName(string name)
        {
           return _repositoryDbContext.RoleClaimsMapping.Where(x => (x.ClaimValue == name || x.ClaimType == name) && !x.IsDeleted).FirstOrDefault();
        }

        public List<RoleClaimsMapping> GetRoleClaimsByRoleId(int roleId)
        {
            return _repositoryDbContext.RoleClaimsMapping.Where(x => x.RoleId == roleId && !x.IsDeleted).ToList();
        }
    }
}
