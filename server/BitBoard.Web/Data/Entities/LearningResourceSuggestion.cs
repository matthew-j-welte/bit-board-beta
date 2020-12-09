using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("LearningResourceSuggestion")]
    public class LearningResourceSuggestion : BaseEntity
    {
        public int LearningResourceSuggestionId { get; set; }

        public string SourceUrl { get; set; }
        public string Rationale { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<LearningResourceSuggestionSkill> LearningResourceSuggestionSkills { get; set; }
    }
}