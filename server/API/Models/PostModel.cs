using System.Collections.Generic;
using API.Models.DTOs;

namespace API.Models
{
    public class PostModel : PostDto
    {
        public ICollection<PostCommentDto> Comments { get; set; }
    }
}