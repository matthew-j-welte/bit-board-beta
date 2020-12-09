using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int YearsExperience { get; set; }
        public string Title { get; set; }
        public string TechnicalSummary { get; set; }
        public string CurrentEmployer { get; set; }
        public int YearsAtEmployer { get; set; }
        public string JobDescription { get; set; }

        // public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserSkill> UserSkills { get; set; }
        public ICollection<UserResourceState> UserResourceStates { get; set; }
        public ICollection<UserPostRelationship> UserPostRelationships { get; set; }
        public ICollection<LearningResource> LearningResources { get; set; }
        public ICollection<CodeEditorConfiguration> CodeEditorConfigurations { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}