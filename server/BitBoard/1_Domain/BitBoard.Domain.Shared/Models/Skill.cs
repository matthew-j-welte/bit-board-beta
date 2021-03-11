namespace BitBoard.Domain.Shared.Models
{
    public class Skill : BaseStaticEntity<Skill>
    {
        public string SkillId => this.Id;
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Category { get; set; }
        public string BgColorHex { get; set; }
    }
}
