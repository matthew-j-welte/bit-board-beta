using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}