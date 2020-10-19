using System.Collections.Generic;

namespace API.Models.Entities
{
    public class LearningResource
    {
        public int LearningResourceId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Viewers { get; set; }

        public string Placeholder { get; set; }
        public string VideoId { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Skill> AssociatedSkills { get; set; }
    }
}