using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("ErrorReport")]
    public class ErrorReport : BaseEntity
    {
        public int ErrorReportId { get; set; }
        
        public User UserSource { get; set; }
        public string Error { get; set; }
        public string Type { get; set; }
        public string Contents { get; set; }

    }
}