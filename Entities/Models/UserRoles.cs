using Microsoft.AspNetCore.Identity;


namespace Entities.Models
{
    public class UserRoles : IdentityUserRole<int>
    {
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
