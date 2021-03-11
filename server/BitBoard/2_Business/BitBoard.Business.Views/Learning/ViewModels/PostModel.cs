using System.Collections.Generic;
using BitBoard.Business.Views.Learning.Dtos;

namespace BitBoard.Business.Views.Learning.ViewModels
{
    public class PostModel : PostDto
    {
        public ICollection<PostCommentDto> Comments { get; set; }
    }
}