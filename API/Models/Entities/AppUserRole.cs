using API.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Models.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}