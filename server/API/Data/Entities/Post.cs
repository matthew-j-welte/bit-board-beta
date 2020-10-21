using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("Post")]
    public class Post : BaseEntity
    {
        public int PostId { get; set; }

        public string Content { get; set; }
        public int Likes { get; set; }
        public int Reports { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public int LearningResourceId { get; set; }
        public LearningResource LearningResource { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}