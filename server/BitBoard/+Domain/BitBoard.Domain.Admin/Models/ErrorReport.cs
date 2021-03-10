using System.ComponentModel.DataAnnotations.Schema;

namespace BitBoard.Domain.Admin.Models
{
    public class ErrorReport : BaseEntity
    {
        public string ErrorReportId => this.Id;
        public string Error { get; set; }
        public string Type { get; set; }
        public string Contents { get; set; }

    }
}