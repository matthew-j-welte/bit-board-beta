using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string JobRole { get; set; }
        public int YearsExperience { get; set; }
        public string CareerSummary { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserSkill> UserSkills { get; set; }
        public ICollection<LearningResourceSuggestion> ResourceSuggestions { get; set; }
        public ICollection<LearningResource> PublishedLearningResources { get; set; }
    }
}