using System.Collections.Generic;

namespace API.Data.Entities
{
    public class LearningResourceSuggestion : BaseEntity
    {
        public string LearningResourceSuggestionId => this.Id;
        public string SourceUrl { get; set; }
        public string Rationale { get; set; }
        public LearningResourceSuggestionUser Author { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }

    public class LearningResourceSuggestionUser
    {
        public string UserId { get; set; }
        public string Username { get; set; }
    }
}