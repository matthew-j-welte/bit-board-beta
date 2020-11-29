namespace API.Models.DTOs
{
    public class UserResourceProgressDto
    {
        public LearningResourceDto LearningResource { get; set; }
        public UserDto User { get; set; }
        public int ProgressPercent { get; set; }
    }
}