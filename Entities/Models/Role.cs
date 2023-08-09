using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Role : IdentityRole<int>
    {
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
        public virtual List<RoleClaimsMapping> RoleClaimsMapping { get; set; } = new List<RoleClaimsMapping>();
    }
}
