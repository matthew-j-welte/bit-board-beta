namespace API.Models.Entities
{
    public class LearningResourcePost
    {
        public string Content { get; set; }
        public string Username { get; set; }
        public string ProfileImageUrl { get; set; }
        public int Likes { get; set; }
        public int Reports { get; set; }
        public int Posted { get; set; }
    }
}