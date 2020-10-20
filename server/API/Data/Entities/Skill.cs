using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Entities
{
    [Table("Skill")]
    public class Skill : BaseEntity
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Category { get; set; }

        public ICollection<LearningResourceSkill> LearningResourceSkills { get; set; }
    }
}
