using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsExperience { get; set; }
        public string CareerSummary { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        
        // public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserSkill> UserSkills { get; set; }
        public ICollection<LearningResource> LearningResources { get; set; }
    }
}