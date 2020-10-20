using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Entities
{
    [Table("UserSkill")]
    public class UserSkill : BaseEntity
    {
        public int UserSkillId { get; set; }

        public Skill Skill { get; set; }
        public int SkillId { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }

        public int Level { get; set; }
        public int ProgressPercent { get; set; }
    }
}
