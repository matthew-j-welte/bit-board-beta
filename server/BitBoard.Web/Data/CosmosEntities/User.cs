using System.Collections.Generic;
using API.Enums;

namespace API.Data.Entities
{
    public class User : BaseEntity
    {
        public string UserId => this.Id;
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
        public IEnumerable<UserSkill> UserSkills { get; set; }
        public IEnumerable<UserResourceState> UserResourceStates { get; set; }
        public IEnumerable<UserPostRelationship> UserPostRelationships { get; set; }
        public IEnumerable<UserLearningResource> AuthoredResources { get; set; }
        public IEnumerable<UserEditorConfiguration> CodeEditorConfigurations { get; set; }
        public IEnumerable<UserPost> Posts { get; set; }
        public IEnumerable<UserComment> Comments { get; set; }
    }

    public class UserSkill
    {

        public string SkillId { get; set; }
        public string SkillName { get; set; }
        public int Level { get; set; }
        public int ProgressPercent { get; set; }
    }

    public class UserResourceState
    {
        public string LearningResourceId { get; set; }
        public string LearningResourceName { get; set; }
        public int ProgressPercent { get; set; }
    }

    public class UserPostRelationship
    {
        public UserPostActionEnum UserPostAction { get; set; }
        public UserPost Post { get; set; }
    }

    public class UserLearningResource
    {
        public string LearningResourceId { get; set; }
        public string LearningResourceName { get; set; }
    }

    public class UserEditorConfiguration
    {
        public string EditorConfigurationId { get; set; }
        public string EditorConfigurationName { get; set; }
    }

    public class UserPost
    {
        public string PostId { get; set; }
        public string Title { get; set; }
    }

    public class UserComment
    {
        public string CommentId { get; set; }
        public string PostId { get; set; }
        public string PostTitle { get; set; }
    }
}