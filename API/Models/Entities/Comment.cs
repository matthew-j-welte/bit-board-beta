using System;

namespace API.Models.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        // Can probably be removed - this is more of a DTO field (even though we prolly wont use this in the DTO either)
        public string Author { get; set; }
        public DateTime DatePosted { get; set; }
        public string Content { get; set; }

        public int UserIdPostedBy { get; set; }
        public User UserPostedBy { get; set; }
    }
}
