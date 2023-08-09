

using Entities.Models;

namespace Repositories.Contracts
{
    public interface IRoleClaimRepository
    {
        RoleClaimsMapping GetRoleClaimsByName(string name);
        RoleClaimsMapping GetRoleClaimsById(int id);
        List<RoleClaimsMapping> GetRoleClaims();
        List<RoleClaimsMapping> GetRoleClaimsByRoleId(int roleId);
    }
}
