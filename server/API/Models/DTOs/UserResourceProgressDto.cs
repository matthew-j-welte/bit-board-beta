namespace API.Models.DTOs
{
    public class UserResourceStateDto
    {
        public LearningResourceDto LearningResource { get; set; }
        public UserDto User { get; set; }
        public int ProgressPercent { get; set; }
    }
}