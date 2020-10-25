namespace API.Models.DTOs
{
    public class PostCommentDto
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public PostDto Post { get; set; }
    }
}