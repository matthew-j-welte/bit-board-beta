using System;

namespace BitBoard.Domain.Shared.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateModified = DateTime.UtcNow;

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
        }
    }
}