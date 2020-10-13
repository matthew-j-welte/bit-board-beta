namespace API.Models.Entities
{
    public class UserSkill
    {
        public Skill AssociatedSkill { get; set; }
        public int Level { get; set; }
        public int PercentToNextLevel { get; set; }
    }
}
