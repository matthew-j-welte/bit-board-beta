using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Models.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}