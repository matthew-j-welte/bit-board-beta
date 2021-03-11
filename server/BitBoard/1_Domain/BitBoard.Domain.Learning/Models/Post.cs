using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BitBoard.Domain.Shared.Models;

namespace BitBoard.Domain.Learning.Models
{
    public class Post : BaseEntity
    {
        public string PostId => this.Id;
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Reports { get; set; }

        public PostUser User { get; set; }
        public PostLearningResource LearningResource { get; set; }
        public IEnumerable<PostComment> Comments { get; set; }
    }

    public class PostUser
    {
        public string UserId { get; set; }
        public string Username { get; set; }
    }
    public class PostLearningResource
    {
        public string LearningResourceId { get; set; }
        public string Title { get; set; }
    }

    public class PostComment
    {
        public string CommentId { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
    }
}