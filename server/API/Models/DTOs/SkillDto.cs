namespace API.Models.DTOs
{
    public class SkillDto
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Category { get; set; }
        public string BgColorHex { get; set; }
    }
}