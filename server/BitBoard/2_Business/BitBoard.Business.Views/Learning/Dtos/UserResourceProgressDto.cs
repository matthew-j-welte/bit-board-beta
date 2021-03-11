using BitBoard.Business.Views.Account.Dtos;

namespace BitBoard.Business.Views.Learning.Dtos
{
    public class UserResourceStateDto
    {
        public LearningResourceDto LearningResource { get; set; }
        public UserDto User { get; set; }
        public int ProgressPercent { get; set; }
    }
}