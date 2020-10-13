using System;

namespace API.Models.Entities
{
    public class LearningResourcePostComment
    {
        public string Author { get; set; }
        public DateTime DatePosted { get; set; }
        public string Content { get; set; }
    }
}
