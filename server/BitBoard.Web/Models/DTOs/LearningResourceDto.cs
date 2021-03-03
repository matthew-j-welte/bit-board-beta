using System.Collections.Generic;

namespace API.Models.DTOs
{
    public class LearningResourceDto
    {
        public string LearningResourceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string VideoId { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public int Viewers { get; set; }
        public string UserId { get; set; }

        public ICollection<SkillDto> Skills { get; set; }
    }
}