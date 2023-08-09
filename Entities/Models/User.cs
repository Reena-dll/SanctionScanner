using Microsoft.AspNetCore.Identity;


namespace Entities.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PersonnelNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
        public virtual List<Rent> RentList { get; set; }
    }
}
