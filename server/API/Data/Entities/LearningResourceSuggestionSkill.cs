using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("LearningResourceSuggestionSkill")]
    public class LearningResourceSuggestionSkill
    {
        public int LearningResourceSuggestionSkillId { get; set; }
        
        public int LearningResourceSuggestionId { get; set; }
        public LearningResourceSuggestion LearningResourceSuggestion { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}