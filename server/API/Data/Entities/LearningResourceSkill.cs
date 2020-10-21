using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("LearningResourceSkill")]
    public class LearningResourceSkill
    {
        public int LearningResourceSkillId { get; set; }
        
        public int LearningResourceId { get; set; }
        public LearningResource LearningResource { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}