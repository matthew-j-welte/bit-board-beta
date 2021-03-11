using System.Collections.Generic;
using BitBoard.Business.Views.Learning.Dtos;

namespace BitBoard.Business.Views.Learning.ViewModels
{
    public class LearningResourceModel : LearningResourceDto
    {
        public ICollection<PostDto> Posts { get; set; }
        public UserResourceStateDto UserResourceProgression { get; set; }
    }
}