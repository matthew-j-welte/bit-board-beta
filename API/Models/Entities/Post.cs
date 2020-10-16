using System.Collections.Generic;

namespace API.Models.Entities
{
    public class Post
    {
        public string Content { get; set; }
        // Will most likely only be needed in the DTO
        public string Username { get; set; }
        // Will most likely only be needed in the DTO
        public string ProfileImageUrl { get; set; }
        public int Likes { get; set; }
        public int Reports { get; set; }
        public int Posted { get; set; }

        public int UserIdPostedBy { get; set; }
        public User UserPostedBy { get; set; }
        public LearningResource LearningResource { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}