using System.Collections.Generic;
using BitBoard.Business.Views.Account.Dtos;
using BitBoard.Business.Views.Learning.Dtos;

namespace BitBoard.Business.Views.Account.ViewModels
{
    public class UserModel : UserDto
    {
        public ICollection<UserSkillDto> UserSkills { get; set; }
        public ICollection<LearningResourceDto> LearningResources { get; set; }
        public ICollection<CodeEditorConfigurationDto> CodeEditorConfigurations { get; set; }
        public ICollection<PostDto> Posts { get; set; }
        public ICollection<PostCommentDto> Comments { get; set; }
    }
}