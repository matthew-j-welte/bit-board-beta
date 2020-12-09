using API.Enums;

namespace API.Models.DTOs
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Reports { get; set; }
        public int UserId { get; set; }
        public int LearningResourceId { get; set; }
        public LearningResourceDto LearningResource { get; set; }
        public UserPostActionEnum UserPostAction { get; set; }
        public UserPostActionEnum PreviousUserPostAction { get; set; }
    }
}