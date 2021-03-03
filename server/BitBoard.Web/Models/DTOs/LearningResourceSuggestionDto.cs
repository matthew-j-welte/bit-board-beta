using System.Collections.Generic;

namespace API.Models.DTOs
{
    public class LearningResourceSuggestionDto
    {
        public string UserId { get; set; }
        public string SourceUrl { get; set; }
        public string Rationale { get; set; }
        public ICollection<SkillDto> Skills { get; set; }
    }
}