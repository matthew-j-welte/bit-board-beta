namespace API.Models.Entities
{
    public class UserSkill
    {
        public Skill Skill { get; set; }
        public int SkillId { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }

        public int Level { get; set; }
        public int PercentToNextLevel { get; set; }
    }
}
