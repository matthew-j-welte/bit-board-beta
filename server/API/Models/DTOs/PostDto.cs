namespace API.Models.DTOs
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        
        public int LearningResourceId { get; set; }
        public LearningResourceDto LearningResource { get; set; }
    }
}