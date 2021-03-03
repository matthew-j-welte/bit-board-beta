namespace API.Models.DTOs
{
    public class PostCommentDto
    {
        public string CommentId { get; set; }
        public string Content { get; set; }
        public string PostId { get; set; }
        public PostDto Post { get; set; }
    }
}