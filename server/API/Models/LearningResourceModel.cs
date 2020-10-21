using System.Collections.Generic;
using API.Models.DTOs;

namespace API.Models
{
    public class LearningResourceModel : LearningResourceDto
    {
        public ICollection<PostDto> Posts { get; set; }
        public ICollection<SkillDto> Skills { get; set; }
    }
}