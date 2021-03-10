namespace BitBoard.Domain.Learning.Models
{
    public class LearningResource : BaseEntity
    {
        public string LearningResourceId => this.Id;

        public string Title { get; set; }
        public string Description { get; set; }
        public int Viewers { get; set; }

        public string Placeholder { get; set; }
        public string VideoId { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public LearningResourceUser Author { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }

    public class LearningResourceUser
    {
        public string UserId { get; set; }
        public string Username { get; set; }
    }
}