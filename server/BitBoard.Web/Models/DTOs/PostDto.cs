using API.Enums;

namespace API.Models.DTOs
{
    public class PostDto
    {
        public string PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Reports { get; set; }
        public string UserId { get; set; }
        public string LearningResourceId { get; set; }
        public PostLearningResourceDto LearningResource { get; set; }
        public UserPostActionEnum UserPostAction { get; set; }
        public UserPostActionEnum PreviousUserPostAction { get; set; }
    }

    public class PostLearningResourceDto
    {
        public string LearningResourceId { get; set; }
        public string Title { get; set; }
    }
}