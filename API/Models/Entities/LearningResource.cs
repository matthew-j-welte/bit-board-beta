using System.Collections.Generic;

namespace API.Models.Entities
{
    public class LearningResource
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Viewers { get; set; }
        public List<string> Posts { get; set; }
        public List<string> AssociatedSkills { get; set; }
        public string Placeholder { get; set; }
        public string VideoId { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
    }
}