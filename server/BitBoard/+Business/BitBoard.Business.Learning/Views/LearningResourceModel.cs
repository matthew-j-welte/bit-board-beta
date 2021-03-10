using System.Collections.Generic;
using API.Models.DTOs;

namespace BitBoard.Business.Learning.Views
{
    public class LearningResourceModel : LearningResourceDto
    {
        public ICollection<PostDto> Posts { get; set; }
        public UserResourceStateDto UserResourceProgression { get; set; }
    }
}