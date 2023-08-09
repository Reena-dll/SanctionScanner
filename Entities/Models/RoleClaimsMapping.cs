

namespace Entities.Models
{
    public class RoleClaimsMapping : BaseEntity
    {
        public int RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public virtual Role Role { get; set; }
    }
}
