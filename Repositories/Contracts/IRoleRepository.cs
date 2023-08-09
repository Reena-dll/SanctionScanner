
using Entities.Models;

namespace Repositories.Contracts
{
    public interface IRoleRepository
    {
        Role GetRoleByName(string name);
        Role GetRoleById(int id);
        List<Role> GetAllRole();
    }
}
