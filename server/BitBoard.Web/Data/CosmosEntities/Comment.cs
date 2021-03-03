namespace API.Data.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentId => this.Id;
        public string Content { get; set; }
        public CommentUser Author { get; set; }
        public CommentPost ParentPost { get; set; }
    }

    public class CommentUser
    {
        public string UserId { get; set; }
        public string Username { get; set; }
    }

    public class CommentPost
    {
        public string PostId { get; set; }
        public string Title { get; set; }
    }
}
