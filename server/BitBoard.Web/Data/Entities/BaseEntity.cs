using System;

namespace API.Data.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }    

        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
        }
    }
}