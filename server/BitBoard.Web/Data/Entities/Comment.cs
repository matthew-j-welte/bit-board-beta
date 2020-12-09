using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("Comment")]
    public class Comment : BaseEntity
    {
        public int CommentId { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
