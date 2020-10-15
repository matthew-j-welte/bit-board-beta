using API.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Models.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}