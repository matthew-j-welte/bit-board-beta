using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Data.Entities
{
    [Table("UserPostRelationship")]
    public class UserPostRelationship : BaseEntity
    {
        public int Id { get; set; }
        public UserPostActionEnum UserPostAction { get; set; }

        // Relationships
        public User User { get; set; }
        public int UserId { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public LearningResource LearningResource { get; set; }
        public int LearningResourceId { get; set; }
    }
}