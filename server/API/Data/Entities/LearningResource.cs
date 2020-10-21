using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("LearningResource")]
    public class LearningResource : BaseEntity
    {
        public int LearningResourceId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Viewers { get; set; }

        public string Placeholder { get; set; }
        public string VideoId { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<Post> Posts { get; set; }
        public ICollection<LearningResourceSkill> LearningResourceSkills { get; set; }
    }
}