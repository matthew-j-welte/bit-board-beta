using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("UserResourceState")]
    public class UserResourceState : BaseEntity
    {
        public int Id { get; set; }
        public int ProgressPercent { get; set; }

        // Relationships 
        public LearningResource LearningResource { get; set; }
        public int LearningResourceId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}