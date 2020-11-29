using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("UserResourceProgress")]
    public class UserResourceProgress : BaseEntity
    {
        public int Id { get; set; }
        public LearningResource LearningResource { get; set; }
        public int LearningResourceId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int ProgressPercent { get; set; }
    }
}