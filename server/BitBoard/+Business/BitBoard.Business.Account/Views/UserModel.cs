using System.Collections.Generic;
using API.Models.DTOs;

namespace BitBoard.Business.Account.Views
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