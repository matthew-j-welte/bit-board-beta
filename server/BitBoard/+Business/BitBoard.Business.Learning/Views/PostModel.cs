using System.Collections.Generic;
using API.Models.DTOs;

namespace BitBoard.Business.Learning.Views
{
    public class PostModel : PostDto
    {
        public ICollection<PostCommentDto> Comments { get; set; }
    }
}